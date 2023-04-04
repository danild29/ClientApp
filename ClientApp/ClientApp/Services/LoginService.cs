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
        private ObservableCollection<EventModel> EventList = new ObservableCollection<EventModel>();

        
        public LoginService()
        {

            MakeUser();
            MakeEvents();

            

        }

		public void GetMyTeam()
        {
            int? id = UserData.TeamId;
            if (id < 0 || id == null) return;

            MyTeam = MakeTeam();

        }



		public bool AddUser(User user)
        {

            if(!IsUserExistInDataBase(user.LoginName))
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
            foreach(var user in userList)
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
            foreach(var user in userList)
            {
                if (user.Id == id)
                    return user;
            }
            return null;
        }


        // ===================================================== temporariy
        // ===================================================== temporariy
        // ===================================================== temporariy

        private void MakeUser()
        {
            userList.Add(new User("user1", "123", "zxc"));
            userList.Add(new User("user2", "qwerty", "zxc"));
            userList.Add(new User("n", "m", "zxc"));
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
