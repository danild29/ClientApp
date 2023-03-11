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
            User user = new User(UserName, UserPassword);

            if (ilog.AddUser(user))
            {
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
            App.Current.MainPage.Navigation.PushAsync(new MainPage());
        }

        // ========================================
        

        private string userName;
        private string userPassword;

        public string UserName
        {
            get => userName;
            set
            {
                userName = value;
                OnPropertyChanged(nameof(UserName));
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
