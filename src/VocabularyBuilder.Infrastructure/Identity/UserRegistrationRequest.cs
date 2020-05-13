﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VocabularyBuilder.Infrastructure.Identity
{
    public class UserRegistrationRequest
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}