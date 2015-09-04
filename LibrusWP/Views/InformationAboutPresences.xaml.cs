using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LibrusWP.ViewModels;
using LibrusWP.Logic;

namespace LibrusWP.Views
{
    public partial class InrofmationAboutPresences : PhoneApplicationPage
    {
        public InrofmationAboutPresences()
        {
            InitializeComponent();
        }

        public InformationAboutPresencesViewModel ViewModel { get { return this.DataContext as InformationAboutPresencesViewModel; } }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string value = NavigationContext.QueryString["ID"];
            string[] tab = value.Split(new char[] { '/' });
            int id = Convert.ToInt32(tab[0]);
            this.DataContext = new InformationAboutPresencesViewModel(LibrusFactory.CreateLibrusManager(), id, tab[1]);
        }
    }
}