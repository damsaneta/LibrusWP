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
using LibrusWP.DataAccess;

namespace LibrusWP.Views
{
    public partial class SelectionPage : PhoneApplicationPage
    {
        public SelectionPage()
        {
            InitializeComponent();
            this.DataContext = new SelectionPageViewModel(LibrusFactory.CreateLibrusManager());  
        }

        public SelectionPageViewModel ViewModel { get { return this.DataContext as SelectionPageViewModel; } }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string value = string.Empty;

            if (NavigationContext.QueryString.TryGetValue("item", out value))
            {
                this.pivot.SelectedItem = this.summaryPivotItem;
                while (NavigationService.CanGoBack)
                    NavigationService.RemoveBackEntry();
            }

        }

    

        private void PresenceButtonClick(object sender, RoutedEventArgs e)
        {

            var value = this.ViewModel.SelectedClass.Id + "/" + this.ViewModel.SelectedSubject.Id;
            NavigationService.Navigate(new Uri("/Views/CallendarPage.xaml?conclusion=" + value, UriKind.Relative));
        }

        private void ShowPresencesButtonClick(object sender, RoutedEventArgs e)
        {
            var value = this.ViewModel.SelectedClass.Id + "/" + this.ViewModel.SelectedSubject.Id;
            NavigationService.Navigate(new Uri("/Views/StudentsListPage.xaml?summary=" + value, UriKind.Relative));
        }
    }
}