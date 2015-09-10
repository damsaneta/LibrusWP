using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using LibrusWP.Model;
using LibrusWP.ViewModels;
using LibrusWP.Logic;
using System.Globalization;

namespace LibrusWP.Views
{
    public partial class PresencePage : PhoneApplicationPage
    {
        private readonly ILibrusManager manager = LibrusFactory.CreateLibrusManager();
        public PresencePage()
        {
            InitializeComponent();
        }

        public PresencePageViewModel ViewModel { get { return this.DataContext as PresencePageViewModel; } }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string value = string.Empty;

            if (NavigationContext.QueryString.TryGetValue("msg", out value) )
            {
                string[] tab = value.Split(new char[] { '/' });
                this.DataContext = new PresencePageViewModel(LibrusFactory.CreateLibrusManager(), tab[0], tab[1], tab[2]);
            }
            if (this.State.ContainsKey("presences"))
            {
                string[] tab = ((string)this.State["presences"]).Split(new char[] { '/' });
                int i =0;
                foreach(var p in this.ViewModel.Presences)
                {
                    p.Present =  Convert.ToBoolean(tab[i]);
                    i++;
                }
              //  this.ViewModel.Classes.Where(x => x.Id == (string)this.State["selectedClass"]).SingleOrDefault().IsSelected = true;
            }

        }
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back
            && e.NavigationMode != System.Windows.Navigation.NavigationMode.Forward)
            {
                string presences= string.Empty;
                foreach(var p in this.ViewModel.Presences)
                {
                    presences = presences + p.Present.ToString() +"/";
                }
                this.State["presences"] = presences;
            }
        }

        private void ZapiszButtonClick(object sender, RoutedEventArgs e)
        {
            this.manager.SavePresences(this.ViewModel.Presences);
            NavigationService.RemoveBackEntry();
            NavigationService.GoBack();
        }
    }
}