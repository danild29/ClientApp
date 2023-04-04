using ClientApp.Model;
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
    public partial class HomePage : TabbedPage
    {
        public HomePage()
        {
            InitializeComponent();
            ILogin ilog = DependencyService.Get<ILogin>();

            if(ilog.MyTeam == null)
            {
                ilog.GetMyTeam();
            }

            MyTeamPage myteam = new MyTeamPage { Title = "моя команда", IconImageSource = "homeIcon.png" };
            AllEventsPage allEvents = new AllEventsPage { Title = "все мероприятия", IconImageSource = "homeIcon.png" };
            ProfilePage profile = new ProfilePage() { Title = "профиль", IconImageSource = "homeIcon.png" };




            this.Children.Add(myteam);
            this.Children.Add(allEvents);
            if (ilog.UserData.CanCreate)
            {
                MyEventsPage myEvents = new MyEventsPage { Title = "мои мероприятия", IconImageSource = "homeIcon.png" };
                this.Children.Add(myEvents);
            }
            this.Children.Add(profile);
        }
    }

}