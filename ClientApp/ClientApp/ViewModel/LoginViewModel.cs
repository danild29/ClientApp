using ClientApp.Model;
using ClientApp.Services;
using ClientApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        
        ILogin ilog = DependencyService.Get<ILogin>();

        public Command cmdLogin { get; set; }
        public Command cmdCreateAccount { get; set; }
        public Command cmdForgotPassword { get; set; }

        public LoginViewModel()
        {
            cmdLogin = new Command(GoToMainPage);
            cmdCreateAccount = new Command(GoToCreateAccount);
            cmdForgotPassword = new Command(GoToForgotPasswordPage);
        }

        private void GoToMainPage(object obj)
        {
            User user = ilog.Login(UserLoginName, UserPassword);
            if(user != null)
            {
                ilog.UserData = user;
                GoToHomePage();
            }
            else
            {
                LoginMessage = "непраильный имя пользователя или пароль";
                //Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
                App.Current.MainPage.DisplayAlert("Ошибочка", "неправильный имя пользователя или пароль", "OK"); 
                TurnLoginMessage = true;
            }
        }
        private void GoToHomePage()
        {
            var homePage = new HomePage();

            App.Current.MainPage = new NavigationPage(homePage);
            //App.Current.MainPage.Navigation.PushAsync(homePage);
        }

        private void GoToCreateAccount(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new CreateAccountPage());
        }
        private void GoToForgotPasswordPage(object obj)
        {
            App.Current.MainPage.Navigation.PushAsync(new ForgotPasswordPage());
        }

        //--------------------------
        private string userLoginName;
        private string userPassword;

        public string UserLoginName
        {
            get => userLoginName;
            set
            {
                userLoginName = value;
                OnPropertyChanged(nameof(UserLoginName));
            }
        }
        public string UserPassword
        {
            get => userPassword;
            set
            {
                userPassword = value;
                OnPropertyChanged(nameof(UserPassword));
            }
        }

        private string loginMessage;

        public string LoginMessage
        {
            get => loginMessage;
            set
            {
                loginMessage = value;
                OnPropertyChanged(nameof(LoginMessage));
            }
        }

        private bool turnLoginMessage = false;

        public bool TurnLoginMessage
        {
            get => turnLoginMessage;
            set
            {
                turnLoginMessage = value;
                OnPropertyChanged(nameof(TurnLoginMessage));
            }
        }
    }
}
