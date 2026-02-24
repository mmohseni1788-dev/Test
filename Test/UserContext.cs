using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public sealed class UserContext
    {
        public string UserName { get; }
        public string Role { get;}
        public UserContext(string userName , string role)
        {
            UserName = userName;
            Role = role;
        }
    }
}
