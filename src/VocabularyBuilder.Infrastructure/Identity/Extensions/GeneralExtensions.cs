using Microsoft.AspNetCore.Http;
using System.Linq;

namespace VocabularyBuilder.Infrastructure.Identity.Extensions
{
    public static class GeneralExtensions
    {
        public static string GetUserId(this HttpContext httpContext)
        {
            if (httpContext == null)
            {
                return string.Empty;
            }
            return httpContext.User.Claims.Single(x => x.Type == "id").Value;
        }
    }
}
