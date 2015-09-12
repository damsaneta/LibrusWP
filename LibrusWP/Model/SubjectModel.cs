using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace LibrusWP.Model
{
    public class SubjectModel: INotifyPropertyChanged
    {
        private bool isSelected;
        public SubjectModel(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; private set; }

        public string Name { get; private set; }

        public bool IsSelected
        {
            get 
            {
                return this.isSelected;
            }
            set
            {
                if (this.isSelected != value)
                {
                    this.isSelected = value;
                    var handler = this.PropertyChanged;
                    if (handler != null)
                    {
                        handler(this, new PropertyChangedEventArgs("IsSelected"));
                        handler(this, new PropertyChangedEventArgs("StyleName"));
                    }
                }
            }
        }

        public string StyleName { get { return this.IsSelected 
            ? ((Color)Application.Current.Resources["PhoneAccentColor"]).ToString() 
            : "Transparent"; } }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
