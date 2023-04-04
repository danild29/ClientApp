using ClientApp.Services;
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
	public partial class MyTeamPage : ContentPage
	{
		ILogin ilog = DependencyService.Get<ILogin>();

		public int IdTeam => ilog.MyTeam.Id;
		public string Name => ilog.MyTeam.Name;
		public MyTeamPage ()
		{
			InitializeComponent ();
			this.BindingContext = this;



		}

        private void GoToMyTeam(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("GoToMyTeam", IdTeam.ToString(), "ok");
        }
    }
}