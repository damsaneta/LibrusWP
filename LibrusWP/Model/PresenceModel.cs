using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;

namespace LibrusWP.Model
{
    public class PresenceModel: INotifyPropertyChanged
    {
        private bool present;
        public PresenceModel(StudentModel student, TimeTableModel timeTable, DateTime date)
        {
            this.Student = student;
            this.TimeTable = timeTable;
            this.Date = date;
        }
        public PresenceModel(int id,StudentModel student, TimeTableModel timeTable, DateTime date)
            : this(student, timeTable, date)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public StudentModel Student { get; private set; }

        public TimeTableModel TimeTable { get; private set; }

        public DateTime Date { get; private set; }


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
                if(Student.Gender)
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
