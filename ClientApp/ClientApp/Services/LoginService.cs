using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Services
{

    public class LoginService : ILogin
    {

        private List<User> userList = new List<User>();


        public LoginService()
        {
            userList.Add(new User("user1", "123"));
            userList.Add(new User("user2", "qwerty"));
        }

        public bool Login(string username, string password)
        {
            foreach(var user in userList)
            {
                if (user.Name == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
