using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Model
{
    public class Team
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Password { get; set; }

        private User Captain;

        public List<User> Players;

        public Team(string name, string password)
        {
            Name = name;
            Password = password;
            Players= new List<User>();
        }

        public void AddPlayer(User player)
        {
            if (player == null)
            {
                throw new NullReferenceException("the player you wann add is null");
            }
            if (Players.Count == 0)
            {
                Captain = player;
            }
            Players.Add(player);
        }


	}
}
