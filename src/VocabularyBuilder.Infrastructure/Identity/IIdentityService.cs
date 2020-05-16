using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using VocabularyBuilder.Infrastructure.Identity.Enums;

namespace VocabularyBuilder.Infrastructure.Identity
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password, UserRoles? role); 
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
