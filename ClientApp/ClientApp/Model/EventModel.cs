using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ClientApp.Model
{
    public class EventModel
    {
        public int IdEvent { get; set; }
     
        public User Creator { get; set; }
        public string NameEvent { get; set; }
        public string DescriptionEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string Status { get; set; } 
        public string ImageUrl { get; set; }


        private List<Team> Teams;


        public EventModel(string nameEvent, string descriptionEvent)
        {
            NameEvent = nameEvent;
            DescriptionEvent = descriptionEvent;
        }
        public EventModel(string name, string description, string url)
        {
            NameEvent = name;
            DescriptionEvent = description;
            ImageUrl = url;
        }

        public EventModel()
        {

        }
    }
}
