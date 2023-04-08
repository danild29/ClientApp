using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace ClientApp.Services
{

    public class LoginService : ILogin
    {
        public User UserData { get; set; }
        public Team MyTeam { get; set; }

        private List<User> userList = new List<User>();
        private List<Team> teamList = new List<Team>();

        int __teamId = 5;

        private ObservableCollection<EventModel> EventList = new ObservableCollection<EventModel>();


        public LoginService()
        {

            MakeUser();
            MakeEvents();

            MakeTeams();


		}


        public void LeaveMyTeam(int id1, int id2)
        {

            UserData.TeamId = null;
            UserData.TeamPassword = null;
            return;
        }

        public void GetMyTeam()
        {
            int? id = UserData.TeamId;
            if (id < 0 || id == null) return;

            MyTeam = MakeTeam();

        }

        public int? CreateTeam(string name, string password)
        {
            Team createTeam = new Team(name, password);
            createTeam.AddPlayer(UserData);

            createTeam.Id = __teamId;
            teamList.Add(createTeam);
            __teamId++;
            if (true)  //если получилось создать комманду
            {
                return createTeam.Id;
            }


            return null;
        }




        public bool AddUser(User user)
        {

            if (!IsUserExistInDataBase(user.LoginName))
            {
                userList.Add(user);
                return true;
            }

            return false;
        }


        public ObservableCollection<EventModel> GetAllEvents()
        {
            return EventList;
        }




        public User Login(string username, string password)
        {
            foreach (var user in userList)
            {
                if (user.LoginName == username && user.Password == password)
                {

                    return user;
                }
            }
            return null;
        }

        public User GetUserById(int id)
        {
            foreach (var user in userList)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }
        public Team GetTeamById(string newTeamId, string newTeamPassword)
        {
            foreach(Team team in teamList)
            {
                if (team.Id.ToString() == newTeamId && team.Password == newTeamPassword)
                {
                    return team;
                }
            }


            return null;
        }

		// ===================================================== temporariy
		// ===================================================== temporariy
		// ===================================================== temporariy

		private void MakeUser()
        {
            userList.Add(new User("user1", "123", "zxc1"));
            userList.Add(new User("user2", "qwerty", "zxc2"));
            userList.Add(new User("n", "m", "zxc3"));
        }

        private void MakeEvents()
        {
            var image = "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13";
            EventList.Add(new EventModel("First", "description", image));
            EventList.Add(new EventModel("Second", "another", image));
            EventList.Add(new EventModel("Third", "i don't know", image));
            EventList.Add(new EventModel("catacomby", "this is quest with some catacomby", image));


            for(int i = 0; i < EventList.Count; i++)
            {
                EventList[i].Id = i;

                DateTime data = new DateTime(2000 + i, (i % 12) + 1, ((i * 2) % 60) + 1);

                EventList[i].DateEvent = data;
            }

        }


        private Team MakeTeam()
        {
            Team team = new Team("Nd", "11");
            foreach (User user in userList)
            {
                team.AddPlayer(user);
            }
            return team;
        }


        private void MakeTeams()
        {
            for(int i = 0; i < 4; i++)
            {
                string name = "com" + i;
                Team team = new Team(name, i.ToString());
                team.Id = i;
                foreach(User user in userList)
                {
                    team.AddPlayer(user);
                }
                teamList.Add(team);
            }
        }

        // ===================================================== temporariy
        // ===================================================== temporariy
        // ===================================================== temporariy
        //===============================================
        private bool IsUserExistInDataBase(string username)
        {
            foreach (var user in userList)
            {
                if (user.LoginName == username)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
