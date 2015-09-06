using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name = "TimeTables")]
    public class TimeTableEntity
    {
        [Column(Name = "ClassId", CanBeNull = false)]
        private string classId;
        private EntityRef<ClassEntity> classEntity = new EntityRef<ClassEntity>();

        [Column(Name = "SubjectId", CanBeNull = false)]
        private string subjectId;
        private EntityRef<SubjectEntity> subjectEntity = new EntityRef<SubjectEntity>();

        public TimeTableEntity()
        {

        }

        public TimeTableEntity(string day, ClassEntity clazz, SubjectEntity subject)
        {
            this.Day = day;
            this.Class = clazz;
            this.Subject = subject;
        }

        [Column(Name = "Id", IsPrimaryKey = true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        [Column(Name = "Day", CanBeNull = false)]
        public string Day { get; private set; }

        [Association(IsForeignKey = true, Name = "FK_TimeTable_Classes", ThisKey = "classId",
           OtherKey = "Id", Storage = "classEntity")]
        public ClassEntity Class
        {
            get { return this.classEntity.Entity; }
            set { this.classEntity.Entity = value; }
        }

        [Association(IsForeignKey = true, Name = "FK_TimeTable_Subjects", ThisKey = "subjectId",
          OtherKey = "Id", Storage = "subjectEntity")]
        public SubjectEntity Subject
        {
            get { return this.subjectEntity.Entity; }
            set { this.subjectEntity.Entity = value; }
        }

    }
}
