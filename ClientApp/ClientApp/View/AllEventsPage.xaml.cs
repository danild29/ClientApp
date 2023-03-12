using ClientApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AllEventsPage : ContentPage
	{
		public AllEventsPage()
		{
			InitializeComponent ();

			List<EventModel> myList = new List<EventModel>
			{
				new EventModel("First", "description", "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13"),
				new EventModel("Second", "monkey", "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13"),
				new EventModel("Third", "freezer", "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13"),
			};


            myListEvents.ItemsSource = myList;

        }

        private void OnEventTapped(object sender, ItemTappedEventArgs e)
        {
			var selectedEvent = e.Item as EventModel;
			
			if(selectedEvent != null)
			{
				DisplayAlert("Selected", $"{selectedEvent.NameEvent} and {selectedEvent.DescriptionEvent}", "Ok");
			}

        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}