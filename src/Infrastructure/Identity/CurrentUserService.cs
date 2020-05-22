using System.Linq;
using System.Security.Claims;
using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Identity
{
    public class CurrentUserService:ICurrentUserService
    {
        public string UserId { get; }
        public string Role { get; }

        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            UserId = httpContextAccessor.HttpContext?.User?.Claims?.Single(u => u.Type == "id").Value;
            Role = httpContextAccessor.HttpContext?.User?.Claims?.Single(u => u.Type == ClaimTypes.Role).Value;
        }
    }
}
