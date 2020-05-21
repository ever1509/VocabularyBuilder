using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Responses
{
    public class AuthSuccessResponse
    {
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}
