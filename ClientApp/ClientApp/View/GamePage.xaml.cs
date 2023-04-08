using ClientApp.Model;
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
    public partial class GamePage : TabbedPage
    {
        private Team myTeam;

        public GamePage(Team team)
        {
            InitializeComponent();
            myTeam = team;
        }


       
    }
}