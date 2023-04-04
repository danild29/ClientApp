using ClientApp.Model;
using ClientApp.Services;
using ClientApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

		private ObservableCollection<EventModel> EventList;
        ILogin ilog = DependencyService.Get<ILogin>();


        public AllEventsPage()
		{
			InitializeComponent ();

			EventList = ilog.GetAllEvents();

            myListEvents.ItemsSource = EventList;

        }

        private async void OnEventTapped(object sender, ItemTappedEventArgs e)
        {
			var selectedEvent = e.Item as EventModel;
			
			if(selectedEvent != null)
			{
				var eventPage = new EventPage();


				eventPage.BindingContext = new EventViewModel(selectedEvent);

				await Navigation.PushAsync(eventPage);
			}
        }

        private void TextChangedOnSearchBar(object sender, TextChangedEventArgs e)
        {
            myListEvents.ItemsSource = EventList.Where(s => s.Name.StartsWith(e.NewTextValue));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var image = "https://avatars.mds.yandex.net/i?id=0bd48196c8a84bedbb1aa839e70cf91916235a61-7570837-images-thumbs&n=13";
            EventList.Add(new EventModel("catacomby", "this is quest with some real shit", image));
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            if (EventList.Count > 1)
                EventList.RemoveAt(1);
        }
    }
}