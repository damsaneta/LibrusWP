using LibrusWP.Commands;
using LibrusWP.Logic;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibrusWP.ViewModels
{
    public class SelectionPageViewModel : INotifyPropertyChanged
    {
        private readonly ILibrusManager manager;
        public SelectionPageViewModel(ILibrusManager manager)
        {
            this.manager = manager;
            this.Classes = this.manager.GetAllClasses();
            this.SelectClass(this.Classes[0]);
            this.Subjects = new ObservableCollection<SubjectModel>();
            this.RefreshSubjects();
            this.ChangeClassSelection = new ChangeClassSelectionCommand(this);
            this.ChangeSubjectSelection = new ChangeSubjectSelectionCommand(this);
        }

        public ICommand ChangeClassSelection { get; private set; }

        public ICommand ChangeSubjectSelection { get; private set; }

        public List<ClassModel> Classes { get; private set; }

        public ObservableCollection<SubjectModel> Subjects { get; private set;}

        public ClassModel SelectedClass { get { return this.Classes.FirstOrDefault(x => x.IsSelected);  } }

        public SubjectModel SelectedSubject { get { return this.Subjects.Where(x => x.IsSelected).Single(); } }


        public void RefreshSubjects()
        {
            this.Subjects.Clear();
           
            var items = this.manager.GetSubjectsForClass(this.SelectedClass);
            foreach (var item in items)
            {
                this.Subjects.Add(item);
            }
            if(Subjects.Count>0)
            {
                this.SelectSubject(this.Subjects[0]);
            }
            
            //this.Subjects[0].IsSelected = true;
            //if (this.PropertyChanged != null)
            //{
            //    this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedClass"));
            //    this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedSubject"));
            //}
        }

        public void SelectClass(ClassModel selectedItem)
        {
            foreach (var item in this.Classes.Where(x => x.IsSelected))
            {
                item.IsSelected = false;
            }

            selectedItem.IsSelected = true;
            this.NotifyPropertyChanged("SelectedClass");
        }

        public void SelectSubject(SubjectModel selectedItem)
        {
            foreach (var item in this.Subjects.Where(x => x.IsSelected))
            {
                item.IsSelected = false;
            }

            selectedItem.IsSelected = true;
            this.NotifyPropertyChanged("SelectedSubject");
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            var handler = this.PropertyChanged;
            if(handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void SelectSubject2(string p)
        {
            var selectedItem = this.Subjects.Where(x => x.Id == p).SingleOrDefault();
            foreach (var item in this.Subjects.Where(x => x.IsSelected))
            {
                item.IsSelected = false;
            }

            selectedItem.IsSelected = true;
            this.NotifyPropertyChanged("SelectedSubject");
        }
    }
}
