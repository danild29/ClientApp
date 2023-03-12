using ClientApp.Model;
using ClientApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    class AllEventsViewModel: BaseViewModel
    {

        public ObservableCollection<EventModel> eventList = new ObservableCollection<EventModel>
        {
            new EventModel("First", "description", "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13"),
            new EventModel("Second", "monkey", "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13"),
            new EventModel("Third", "freezer", "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13"),
        };


        public Command cmdOnEventTapped { get; set; }

        public AllEventsViewModel()
        {
            cmdOnEventTapped = new Command(EventTapped);
        }

        private void EventTapped()
        {
            

        }
    }
}
