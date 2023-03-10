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
    public class LoginViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
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
            if (ilog.Login(UserName, UserPassword))
            {
                App.Current.MainPage.Navigation.PushAsync(new MainPage());
            }
            else
            {
                LoginMessage = "непраильный имя пользователя или пароль";
                TurnLoginMessage = true;
            }
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
