using System;
using System.Collections.Generic;
using System.Text;

namespace VocabularyBuilder.Infrastructure.Identity
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
