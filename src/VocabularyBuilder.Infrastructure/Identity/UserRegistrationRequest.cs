using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using VocabularyBuilder.Infrastructure.Identity.Enums;

namespace VocabularyBuilder.Infrastructure.Identity
{
    public class UserRegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public UserRoles? Role { get; set; }
    }
}
