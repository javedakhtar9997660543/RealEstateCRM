using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AdminProject.CommonLayer.Aspects.Constants;
using AdminProject.PersistenceLayer.Entities.Entities;
using AdminProject.PersistenceLayer.Entities.Specifications;
using AdminProject.PersistenceLayer.Repository.PersistenceServices;
using AdminProject.PersistenceLayer.Repository.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace AdminProject.CommonLayer.Infrastructure
{

    public interface ITokenClaimsService
    {
        Task<string> GetTokenAsync(int id);
        Task<string> GetToken(int id);
    }

    public class IdentityTokenClaimService : ITokenClaimsService
    {
        private readonly IUserRepository _userRepository;
        private readonly IAsyncRepository<RoleMaster> _roleRepository;
        private readonly IAsyncRepository<UserRoles> _userRoleRepository;
        private readonly IConfiguration _configuration;
        public IdentityTokenClaimService(
             IConfiguration configuration,
             IUserRepository userRepository,
            IAsyncRepository<RoleMaster> roleRepository,
            IAsyncRepository<UserRoles> userRoleRepository)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userRoleRepository = userRoleRepository;
            _configuration = configuration;
        }

        public async Task<string> GetToken(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("AppSettings:Secret"));
            var user = await _userRepository.GetUserAsync(id);
            var role = await _userRepository.GetUserRolesAsync(id);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.MobilePhone, user.Mobile),
                    new Claim(ClaimTypes.Role, role.FirstOrDefault()?.Name)
                }),
                Expires = DateTime.UtcNow.AddSeconds(_configuration.GetValue<int>("Tokens:Lifetime")),
                IssuedAt = DateTime.UtcNow,
                Issuer = "AdminProject",
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string> GetTokenAsync(int id)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AuthorizationConstants.JwtSecretKey);
            var user = await _userRepository.GetUserAsync(id);
            var specification = new UserRoleFilterSpecification(id);
            var role = _roleRepository.GetByIdAsync(_userRoleRepository.FirstOrDefaultAsync(specification).Result.RoleId).Result.Name;
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, id.ToString()),
                new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                new Claim(ClaimTypes.Email, user.Email)
            };
            claims.Add(new Claim(ClaimTypes.Role, role));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                IssuedAt = DateTime.UtcNow,
                Issuer = "AdminProject",
                Expires = DateTime.UtcNow.AddSeconds(_configuration.GetValue<int>("Tokens:Lifetime")),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

    }
}
