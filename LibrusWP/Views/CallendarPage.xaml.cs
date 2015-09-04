using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LibrusWP.Logic;

namespace LibrusWP.Views
{
    public partial class CallendarPage : PhoneApplicationPage
    {
        private readonly ILibrusManager manager = LibrusFactory.CreateLibrusManager(); 

        string value = string.Empty;
        public CallendarPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string w = string.Empty;
            
            if (NavigationContext.QueryString.TryGetValue("conclusion", out w))
            {
                this.value = w;
            }
            //string[] tab = value.Split(new char[] { '/' });
            //DateTime date = manager.FindLastPresencesByClassAndSubject(tab[0], tab[1]);
           // this.datePicker.Value = date;
            //klasa i przedmiot

        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {

            var z = this.datePicker.Value.ToString()+"/" + this.value; 
            NavigationService.Navigate( new Uri("/Views/PresencePage.xaml?msg="+ z,  UriKind.Relative));
            //NavigationService.Navigate(new Uri("/Views/SelectionPage.xaml", UriKind.Relative));
        }
    }
}