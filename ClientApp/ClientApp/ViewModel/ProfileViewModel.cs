using ClientApp.Services;
using ClientApp.View;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    class ProfileViewModel: BaseViewModel
    {

        ILogin ilog = DependencyService.Get<ILogin>();

        public string Name => ilog.UserData.NickName; 

        public Command cmdLogOut { get; set; }

        public ProfileViewModel()
        {
            cmdLogOut = new Command(LogOut);
        }

        private void LogOut()
        {
            ilog.UserData = null;
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}
