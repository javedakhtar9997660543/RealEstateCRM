using AdminProject.BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace AdminProject.PresentationLayer.WebApi.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = Convert.ToInt32(httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        public int UserId { get; }
    }
}
