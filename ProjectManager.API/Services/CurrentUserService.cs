using Application.Contracts.Identity;
using IdentityModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjectManager.API.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var email = httpContextAccessor.HttpContext?.User?.FindFirstValue(JwtClaimTypes.Email);

            Email = email;

            IsAuthenticated = !string.IsNullOrEmpty(email);
        }
    }
}
