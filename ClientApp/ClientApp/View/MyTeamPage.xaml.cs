using ClientApp.Model;
using ClientApp.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public Team team;

        public string errorMessage;

        public string ErrorMessage { get
			{
				return errorMessage;
			}
			set
			{
				errorMessage = value;
				OnPropertyChanged(nameof(ErrorMessage));
			}
		}
        ///============================================ вход в команду

        private string newTeamId;
		private string newTeamPassword;

		public string NewTeamId
		{
			get => newTeamId;
			set
			{
				newTeamId = value;
			}
		}
		public string NewTeamPassword
		{
			get => newTeamPassword;
			set
			{
				newTeamPassword = value;
			}
		}

		private void LogNewTeam(object sender, EventArgs e)
		{
			team = ilog.GetTeamById(newTeamId, newTeamPassword);
			
			if(team == null)
			{
				App.Current.MainPage.DisplayAlert("error", "not correct id or password", "ok");
			}
			else if(team != null)
			{
				string s = team.Name == null ? "qv" : team.Name;
				App.Current.MainPage.DisplayAlert("logging", s , "ok");

				if (int.TryParse(newTeamId, out int res))
				{
					ErrorMessage = "";
                    ilog.UserData.TeamId = res;
				}
				else
				{
					ErrorMessage = "id дожен быть интом";
					return;
				}


				team.AddPlayer(ilog.UserData);

				ilog.UserData.Password = newTeamPassword;
				HasTeam = true;
				myTeamatesList.ItemsSource = team.Players;
			}
		}
        ///============================================ 
        /// =========================================== создание новой команды
        private string createTeamName;
        private string createTeamPassword;

        public string CreateTeamName
        {
            get => createTeamName;
            set
            {
                createTeamName = value;
            }
        }
        public string CreateTeamPassword
        {
            get => createTeamPassword;
            set
            {
                createTeamPassword = value;
            }
        }
        private void CreateTeam(object sender, EventArgs e)
        {
			int? ID = ilog.CreateTeam(createTeamName, createTeamPassword);

			if(ID != null)
			{
                team = ilog.GetTeamById(ID.ToString(), createTeamPassword);

                if (team == null)
                {
                    App.Current.MainPage.DisplayAlert("error", "not correct id or password", "ok");
                }
                else if (team != null)
                {
                    string s = team.Name == null ? "qv" : team.Name;
                    App.Current.MainPage.DisplayAlert("creating", s, "ok");

                    ilog.UserData.TeamId = ID;
                    ilog.UserData.Password = createTeamPassword;
                    HasTeam = true;
                    myTeamatesList.ItemsSource = team.Players;
                }
            }

        }

        ///============================================

        public MyTeamPage ()
		{
			InitializeComponent ();
			BindingContext = this;

			if(ilog.UserData.TeamId == null || ilog.UserData.TeamId < 0)
			{
				HasTeam = false;
				myTeamatesList.ItemsSource = null;
			}
			else
			{
				team = ilog.GetTeamById(ilog.UserData.TeamId.ToString(), ilog.UserData.TeamPassword);
				App.Current.MainPage.DisplayAlert("logging", "exit" + team.Name, "ok");
				HasTeam = true;

				myTeamatesList.ItemsSource = team.Players;
			}


		}


		private bool hasTeam;
		public bool ShowLogging
		{
			get => (!hasTeam);
		}

		public bool HasTeam
		{
			get
			{
				//App.Current.MainPage.DisplayAlert("logging", hasTeam.ToString(), "ok");

				return hasTeam;
			}
			set
			{
				hasTeam = value;
				OnPropertyChanged(nameof(HasTeam));
				OnPropertyChanged(nameof(ShowLogging));
				OnPropertyChanged(nameof(Name));
				OnPropertyChanged(nameof(IdTeam));

			}
		}



		public string Name
		{
			get
			{
				if (HasTeam)
				{
					return team.Name;
				}
				return "...";
			}
		}
		public string IdTeam
		{
			get
			{
				if(HasTeam)
				{

					return "id: " + team.Id.ToString();
				}
				return "id: ";
			}
		}



        private void GoToMyTeam(object sender, EventArgs e)
        {
            App.Current.MainPage.DisplayAlert("GoToMyTeam", IdTeam, "ok");
        }

		private void LeaveTeam(object sender, EventArgs e)
		{
			ilog.LeaveMyTeam(team.Id, ilog.UserData.Id);

			HasTeam = false;
			myTeamatesList.ItemsSource = null;
			//ilog.MyTeam = null;
		}

		private void myTeamates_ItemTapped(object sender, ItemTappedEventArgs e)
		{
			User teammate = e.Item as User;
			if(teammate == null)
	            App.Current.MainPage.DisplayAlert("GoToMyTeam", "error with tema", "ok");
			else
                App.Current.MainPage.DisplayAlert("GoToMyTeam", teammate.NickName, "ok");

        }

        private void StartGame(object sender, EventArgs e)
        {
			GamePage gamePage = new GamePage(team);


            App.Current.MainPage = new NavigationPage(gamePage);
        }

        
    }
}