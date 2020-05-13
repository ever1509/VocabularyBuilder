using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace VocabularyBuilder.Infrastructure.Identity
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
    }
}
