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
using LibrusWP.Model;
using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;

namespace LibrusWP.Views
{
    public partial class AddNewSubjectPage : PhoneApplicationPage
    {
        private string value;
        private readonly ILibrusManager manager;


        public AddNewSubjectPage()
        {
            InitializeComponent();
            manager = LibrusFactory.CreateLibrusManager();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            this.value = NavigationContext.QueryString["class"];
        }

        private void ZapiszButtonClick(object sender, RoutedEventArgs e)
        {
            string name = this.Name.Text;
            string surname = this.Surname.Text;
            bool gender = this.checkGender.IsChecked.Value ? true : false;
            if (name != "" && surname != "")
            {
                IClassRepository claassRepository = LibrusFactory.CreateClassRepository();
                ClassEntity clazz = claassRepository.GetById(this.value);
                StudentEntity student = new StudentEntity(name, surname, clazz, gender);

                IStudentRepository studentRepository = LibrusFactory.CreateStudentRepository();
                studentRepository.AddNew(student);
                NavigationService.GoBack();
            }

        }
    }
}