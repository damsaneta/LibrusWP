using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.Model
{
    public class TimeTableModel
    {
        public TimeTableModel(string day, ClassModel clazz, SubjectModel subject)
        {
            this.Day = day;
            this.Class = clazz;
            this.Subject = subject;
        }

        public TimeTableModel(int id, string day, ClassModel clazz, SubjectModel subject)
            : this(day, clazz, subject)
        {
            this.Id = id;
        }

        public int Id { get; set; }

        public string Day { get; private set; }

        public ClassModel Class { get; private set; }

        public SubjectModel Subject { get; private set; }
    }
}
