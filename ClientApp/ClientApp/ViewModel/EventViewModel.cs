using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClientApp.ViewModel
{
    /// <summary>
    /// надо испрваить костыль с биндингом ивента
    /// </summary>
    public class EventViewModel
    {



        
        private EventModel currentEvent;
        public int IdEvent { get; set; }

        public string NameEvent { get; set; }
        public string DescriptionEvent { get; set; }
        public DateTime DateEvent { get; set; }
        public string ImageUrl { get; set; }

        public EventViewModel(EventModel e)
        {
            currentEvent = e;
            IdEvent= e.IdEvent;
            NameEvent = e.NameEvent;
            DescriptionEvent = e.DescriptionEvent;
            ImageUrl = e.ImageUrl;
            DateEvent = e.DateEvent;
        }


    }
}
