﻿using LibrusWP.Commands;
using LibrusWP.Logic;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibrusWP.ViewModels
{
    public class PresencePageViewModel: INotifyPropertyChanged
    {
        private readonly ILibrusManager manager;

        public PresencePageViewModel(ILibrusManager librusManager, string date, string clazz, string subject)
        {
            this.manager = librusManager;
            this.Date = DateTime.Parse(date);
            this.Class = this.manager.GetClassById(clazz);
            this.Subject = this.manager.GetSubjectById(subject);
            var students = this.manager.GetStudentsByClass(this.Class.Id);
            var timetable = this.manager.GetTimeTable( this.Class, this.Subject);
            IList<PresenceModel> p = this.manager.GetPresencesByStudentsSubjectDate(students, this.Subject, this.Date);
            if (p.Count == 0)
            {
                this.Presences = students.Select(x => new PresenceModel(x, timetable, this.Date)).ToList();
            }
            else
            {
                this.Presences = p;
            }
            //this.Presences = students.Select(x => new PresenceModel(x,timetable, this.Date)).ToList();
            this.ChangePresenceSelection = new ChangePresenceSelectionCommand(this);
        }

        public ICommand ChangePresenceSelection {get; private set;}

        public DateTime Date { get; private set; }

        public SubjectModel Subject { get; private set; }

        public ClassModel Class { get; private set; }

        public IList<PresenceModel> Presences { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
