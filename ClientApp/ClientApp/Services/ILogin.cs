using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClientApp.Services
{
    public interface ILogin
    {
        User UserData { get; set; }
        Team MyTeam { get; set; }

        User Login(string username, string password);
        bool AddUser(User user);
        void GetMyTeam();


		ObservableCollection<EventModel> GetAllEvents();

        User GetUserById(int id);

    }
}
