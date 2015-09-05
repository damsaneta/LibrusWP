using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name= "Presences")]
    public class PresenceEntity
    {
        public PresenceEntity()
        {

        }
        //int studentId, int timeTableId, DateTime date
        public PresenceEntity(DateTime date, bool present)
        {
            this.Date = date;
            this.Present = present;
        }

        [Column(Name = "Id", IsPrimaryKey= true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        //[Column(Name = "StudentId", CanBeNull = false)]
        //public int StudentId { get; private set; }

        //[Column(Name = "TimeTableId", CanBeNull = false)]
        //public int TimeTableId { get; private set; }

        [Column(Name = "Date", CanBeNull = false)]
        public DateTime Date { get; private set; }

        [Column(Name = "Present", CanBeNull = false)]
        public bool Present { get; set; }
    }
}
