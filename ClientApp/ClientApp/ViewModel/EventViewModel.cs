using ClientApp.Model;
using ClientApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    /// <summary>
    /// надо испрваить костыль с биндингом ивента или добавить полную инфу. КРЧ ПЕРЕДЕЛАТЬ
    /// </summary>
    public class EventViewModel
    {
        private EventModel currentEvent;
        
        
        public string Name => currentEvent.Name;
        public string Description => currentEvent.DescriptionEvent;
        public string Image => currentEvent.ImageUrl;
        public int IdEvent => currentEvent.Id;
        
        
        public User Creator { get; set; }
        public DateTime DateEvent { get; set; }
        public string Status { get; set; }
        private List<Team> Teams;


        public Command cmdJoin { get; set; }

        public EventViewModel(EventModel e)
        {
            currentEvent = e;
            cmdJoin = new Command(JoinEvent);
        }

        private void JoinEvent(object obj)
        {
            var homePage = new HomePage();
            App.Current.MainPage = new NavigationPage(homePage);
            //App.Current.MainPage.Navigation.PushAsync(homePage);
        }
    }
}
