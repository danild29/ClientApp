using ClientApp.Services;
using ClientApp.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ClientApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            DependencyService.Register<ILogin, LoginService>();

            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
