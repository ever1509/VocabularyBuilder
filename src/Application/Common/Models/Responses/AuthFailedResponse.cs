using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Responses
{
    public class AuthFailedResponse
    {
        public IEnumerable<string> Errors { get; set; }
    }
}
