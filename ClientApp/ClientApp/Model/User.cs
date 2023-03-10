using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Model
{
    public class User
    {

        public string Name { get; set; }
        public string Password { get; set; }


        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
    }
}
