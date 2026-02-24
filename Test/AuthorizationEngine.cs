using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Test
{
    public static class AuthorizationEngine
    {
        public static void Invoke(object target, string methodName,UserContext user)
        {
            var method = target.GetType().GetMethod(methodName);
            if (method == null) throw new Exception("Method not found!");

            var authAttr = method.GetCustomAttribute<AuthorizationAttribute>();
            if (authAttr != null)
            {
                if (user.Role != authAttr.Role)
                {
                    throw new UnauthorizedAccessException($"Access denied. Required role: {authAttr.Role}");
                }
            }
            method.Invoke(target, null);
        }
    }
}
