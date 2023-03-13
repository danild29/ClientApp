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

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}