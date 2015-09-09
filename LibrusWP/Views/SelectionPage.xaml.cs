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
        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back
            && e.NavigationMode != System.Windows.Navigation.NavigationMode.Forward)
            {

                this.State["pivotItem"] = this.pivot.SelectedIndex.ToString();
                this.State["selectedClass"] = this.ViewModel.SelectedClass.Id;
                this.State["selectedSubject"] = this.ViewModel.SelectedSubject.Id;
            }
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (this.State.ContainsKey("selectedClass"))
            {
                this.ViewModel.Classes[0].IsSelected = false;
                this.ViewModel.Classes.Where(x => x.Id == (string)this.State["selectedClass"]).SingleOrDefault().IsSelected = true;
            }
            //if (this.State.ContainsKey("selectedSubject"))
            //{
            //    this.ViewModel.RefreshSubjects();
            //    this.ViewModel.Subjects[0].IsSelected = false;
            //    this.ViewModel.Subjects.Where(x => x.Id == (string)this.State["selectedSubject"]).SingleOrDefault().IsSelected = true;
            //}
            //if (this.State.ContainsKey("pivotItem"))
            //{
            //    this.pivot.SelectedIndex = Convert.ToInt32(this.State["pivotItem"]);
            //}


        }
    }
}