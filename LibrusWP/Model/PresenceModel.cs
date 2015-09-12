using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using LibrusWP.DataAccess.Entities;

namespace LibrusWP.Model
{
    public class PresenceModel : INotifyPropertyChanged
    {
        private bool present;

        public PresenceModel(StudentModel student, SubjectModel subjectModel, DateTime dateTime, PresenceEntity entity)
        {
            this.Student = student;
            this.Subject = subjectModel;
            if (entity != null)
            {
                this.Id = entity.Id;
                this.Present = entity.Present;
                this.Date = entity.Date;
            }
            else
            {
                this.Date = dateTime;
            }
        }

        public int Id { get; set; }

        public StudentModel Student { get; private set; }

        public DateTime Date { get; private set; }

        public SubjectModel Subject { get; private set; }

        public bool Present
        {
            get { return this.present; }
            set
            {
                if (this.present != value)
                {
                    this.present = value;
                    var handler = this.PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs("Present"));
                        handler(this, new PropertyChangedEventArgs("StyleName"));
                        handler(this, new PropertyChangedEventArgs("TextContent"));
                    }
                }
            }
        }

        public string TextContent
        {
            get
            {
                if (Student.Gender)
                {
                    return this.present ? "obecna" : "nieobecna";
                }
                return this.present ? "obecny" : "nieobecny";

            }
        }

        public string StyleName
        {
            get
            {
                return this.Present
                    ? ((Color)Application.Current.Resources["PhoneAccentColor"]).ToString()
                    : "Transparent";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
