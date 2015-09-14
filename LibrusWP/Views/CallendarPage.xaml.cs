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

            if (this.State.ContainsKey("date"))
            {
                this.datePicker.Value = DateTime.Parse((string)this.State["date"]);
            }

        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (e.Uri.OriginalString != "/Microsoft.Phone.Controls.Toolkit;component/DateTimePickers/DatePickerPage.xaml")
            {
                if (e.NavigationMode != System.Windows.Navigation.NavigationMode.Back
                && e.NavigationMode != System.Windows.Navigation.NavigationMode.Forward)
                {
                    this.State["date"] = this.datePicker.Value.ToString();
                }
            }

        }

        private void AcceptClick(object sender, RoutedEventArgs e)
        {
            var z = this.datePicker.Value.ToString() + "/" + this.value;
            NavigationService.Navigate(new Uri("/Views/PresencePage.xaml?msg=" + z, UriKind.Relative));
        }
    }
}