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
using LibrusWP.Model;

namespace LibrusWP.Views
{
    public partial class StudentsListPage : PhoneApplicationPage
    {
        public StudentsListPage()
        {
            InitializeComponent();
        }

        public StudentsListPageViewModel ViewModel { get { return this.DataContext as StudentsListPageViewModel; } }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            string value = NavigationContext.QueryString["summary"];
            string[] tab = value.Split(new char[] { '/' });
            this.DataContext = new StudentsListPageViewModel(LibrusFactory.CreateLibrusManager(), tab[0], tab[1]);
        }

        private void StudentsListBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(this.studentsListBox.SelectedItems.Count>0)
            {
                string id = (this.studentsListBox.SelectedItem as StudentModel).StudentId.ToString() +"/"+ this.ViewModel.Subject.Id;
                NavigationService.Navigate(new Uri("/Views/InformationAboutPresences.xaml?ID=" +id, UriKind.Relative));
            }
        }
    }
}