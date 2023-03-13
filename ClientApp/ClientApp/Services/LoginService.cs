using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ClientApp.Services
{

    public class LoginService : ILogin
    {

        private List<User> userList = new List<User>();
        private ObservableCollection<EventModel> EventList = new ObservableCollection<EventModel>();
		
        public LoginService()
        {

            MakeUser();
            MakeEvents();

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


        public ObservableCollection<EventModel> GetAllEvents()
        {
            return EventList;
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




        // ===================================================== temporariy
        // ===================================================== temporariy
        // ===================================================== temporariy
        
		private void MakeUser()
        {
            userList.Add(new User("user1", "123"));
            userList.Add(new User("user2", "qwerty"));
            userList.Add(new User("", ""));
        }

        private void MakeEvents()
        {
            var image = "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13";
            EventList.Add(new EventModel("First", "description", image));
            EventList.Add(new EventModel("Second", "monkey", image));
            EventList.Add(new EventModel("Third", "freezer", image));
            EventList.Add(new EventModel("catacomby", "this is quest with some real shit", image));


            for(int i = 0; i < EventList.Count; i++)
            {
                EventList[i].IdEvent = i;

                DateTime data = new DateTime(2000 + i, (i % 12) + 1, ((i * 2) % 60) + 1);

                EventList[i].DateEvent = data;
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
                if (user.Name == username)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
