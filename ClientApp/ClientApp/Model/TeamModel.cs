using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.Model
{
    public class Team
    {
        public int Particpiants { get; set; }
        public String TeamName { get; set; }

        private User Captain;

        private List<User> Players;


    }
}
