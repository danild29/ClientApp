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

        public bool AddUser(User user)
        {

            if(!IsUserExistInDataBase(user.Name))
            {
                userList.Add(user);
                return true;
            }

            return false;
        }


        private bool IsUserExistInDataBase(string username)
        {
            foreach (var user in userList)
            {
                if (user.Name == username)
                {
                    return true;
                }
            }
            return false;
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
