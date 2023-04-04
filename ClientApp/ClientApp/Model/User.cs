using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Model
{
    public class User
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public string NickName { get; set; }
        public string LoginName { get; set; }
        public string Password { get; set; }
        public bool CanCreate { get; set; }
        public List<int> EventsRegistered { get; set; }


        public User(string loginName, string password, string nickName)
        {
            LoginName = loginName;
            Password = password;
            NickName = nickName;
            CanCreate = false;
            EventsRegistered = new List<int>();
        }
    }
}
