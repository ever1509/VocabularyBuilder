using System;
using System.Collections.Generic;
using System.Text;

namespace VocabularyBuilder.Infrastructure.Identity
{
    public class AuthenticationResult
    {
        public string Token { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
