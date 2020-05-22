using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        public string UserId { get; }
        public string Role { get; }
    }
}
