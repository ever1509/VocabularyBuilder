using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class RefreshTokenRequest
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
