using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class AdminService
    {
        [Authorization("Admin")]
        public void AddUser()
        {
            System.Console.WriteLine("user added!");
        }
    }
}
