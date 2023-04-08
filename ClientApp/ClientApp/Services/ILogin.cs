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
        int? CreateTeam(string username, string password);


		ObservableCollection<EventModel> GetAllEvents();

        User GetUserById(int id);
        Team GetTeamById(string newTeamId, string newTeamPassword);
        void LeaveMyTeam(int id1, int id2);
    }
}
