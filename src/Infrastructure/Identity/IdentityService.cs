using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Models;
using Domain.Enums;

namespace Infrastructure.Identity
{
    public class IdentityService:IIdentityService
    {
        public Task<AuthenticationResult> RegisterAsync(string email, string password, UserRole? role)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetUserNameAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
