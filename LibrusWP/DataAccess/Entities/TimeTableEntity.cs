using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name = "TimeTables")]
    public class TimeTableEntity
    {
        public TimeTableEntity()
        {

        }

        public TimeTableEntity(string day)
        {
            this.Day = day;
        }

        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        [Column(Name = "Day", CanBeNull = false)]
        public string Day { get; private set; }

        //[Column(Name = "SubjectId", CanBeNull = false)]
       // public string ClassId { get; private set; }

     //  [Column(Name = "SubjectId", CanBeNull = false)]
       // public string SubjectId { get; private set; }
    }
}
