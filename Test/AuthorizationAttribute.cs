using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    [AttributeUsage(AttributeTargets.Method,AllowMultiple =false,Inherited =true)]
    public sealed class AuthorizationAttribute:Attribute
    {
        public string Role { get; }
        public AuthorizationAttribute(string role)
        {
            Role = role;
        }
    }
}
