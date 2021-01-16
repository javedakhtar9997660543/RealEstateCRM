using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminProject.PresentationLayer.WebApi.Model;
using DreamWedds.CommonLayer.Application.AppSettings;
using DreamWedds.CommonLayer.Application.Interfaces;
using DreamWedds.CommonLayer.Aspects.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AdminProject.PresentationLayer.WebApi.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appsettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appsettings)
        {
            _next = next;
            _appsettings = appsettings.Value;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                attachUserToContext(context, userService, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                IdentityModelEventSource.ShowPII = true;
                var key = Encoding.ASCII.GetBytes(_appsettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "nameid").Value);
                var user = userService.GetUserAsync(userId).Result;
                context.Items["User"] = user;
            }
            catch(Exception ex)
            {
                
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
    }
}
