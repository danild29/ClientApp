using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace ClientApp.Model
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DescriptionEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string Status { get; set; } 
        public string ImageUrl { get; set; }
     

        public User Creator { get; set; }

        public List<Team> Teams;


        public EventModel(string nameEvent, string descriptionEvent)
        {
            Name = nameEvent;
            DescriptionEvent = descriptionEvent;
        }
        public EventModel(string name, string description, string url)
        {
            Name = name;
            DescriptionEvent = description;
            ImageUrl = url;
        }

        public EventModel()
        {

        }
    }
}
