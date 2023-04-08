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
        public Command cmdSetting { get; set; }
        public Command cmdAboutProgram { get; set; }
        public Command cmdPremium { get; set; }

        public ProfileViewModel()
        {
            cmdLogOut = new Command(LogOut);
            cmdSetting = new Command(GoToSettings);
            cmdAboutProgram = new Command(GoToAboutProgram);
            cmdPremium = new Command(GetPremium);
    }

        private void LogOut()
        {
            ilog.UserData = null;
            App.Current.MainPage = new NavigationPage(new LoginPage());
        }
        private void GoToSettings()
        {
            App.Current.MainPage.Navigation.PushAsync(new AboutProgramPage());
        }

        private void GoToAboutProgram()
        {
            App.Current.MainPage.Navigation.PushAsync(new AboutProgramPage());
        }

        private void GetPremium()
        {
            if(ilog.UserData.CanCreate == true)
            {
                App.Current.MainPage.DisplayAlert("уже есть", "уже есть", "ok");
            }
            else
            {
                ilog.UserData.CanCreate = true;
            }
        }
    }
}
