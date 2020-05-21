using System.Threading.Tasks;
using Application.Common.Models;
using Domain.Enums;

namespace Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<AuthenticationResult> RegisterAsync(string email, string password, UserRole? role);
        Task<AuthenticationResult> LoginAsync(string email, string password);
        Task<AuthenticationResult> RefreshTokenAsync(string token, string refreshToken);
        Task<string> GetUserNameAsync(string userId);
    }
}
