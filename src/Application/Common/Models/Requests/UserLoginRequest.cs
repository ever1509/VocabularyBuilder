﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Models.Requests
{
    public class UserLoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
