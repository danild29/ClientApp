using ClientApp.Model;
using ClientApp.Services;
using ClientApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace ClientApp.ViewModel
{
    public class CreateAccountViewModel: BaseViewModel
    {
        ILogin ilog = DependencyService.Get<ILogin>();


        public Command cmdRegister { get; set; }

        public CreateAccountViewModel()
        {
            cmdRegister = new Command(RegisterNewUser);
        }

        private void RegisterNewUser()
        {
            User user = new User(UserLoginName, UserPassword, UserNickName);

            if (ilog.AddUser(user))
            {
                ilog.UserData = user;
                GoToMainPage();
            }
            else
            {
                LoginMessage = "такой пользователь уже зарегестирован";
                TurnLoginMessage = true;
            }
        }

        private void GoToMainPage()
        {
            var homePage = new HomePage();

            App.Current.MainPage = new NavigationPage(homePage);
            //App.Current.MainPage.Navigation.PushAsync(homePage);
        }

        // ========================================
        

        private string userLoginName;
        private string userPassword;
        private string userNickName;

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
        public string UserNickName
        {
            get => userNickName;
            set
            {
                userNickName = value;
                OnPropertyChanged(nameof(UserNickName));
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
