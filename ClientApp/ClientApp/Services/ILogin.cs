using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Services
{
    public interface ILogin
    {

        bool Login(string username, string password);
        bool AddUser(User user);

    }
}
