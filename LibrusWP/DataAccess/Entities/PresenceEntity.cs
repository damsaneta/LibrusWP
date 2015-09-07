using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name= "Presences")]
    public class PresenceEntity
    {
        [Column(Name = "Student", CanBeNull = false)]
        private int studentId;
        private EntityRef<StudentEntity> studentEntity = new EntityRef<StudentEntity>();

        [Column(Name = "Subject", CanBeNull = false)]
        private string subjectId;
        private EntityRef<SubjectEntity> subjectEntity = new EntityRef<SubjectEntity>();

        public PresenceEntity()
        {

        }
        public PresenceEntity(StudentEntity student, SubjectEntity subject, DateTime date, bool present)
        {
            this.Student = student;
            this.Subject = subject;
            this.Date = date;
            this.Present = present;
        }

        [Column(Name = "Id", IsPrimaryKey= true, IsDbGenerated = true, CanBeNull = false)]
        public int Id { get; set; }

        [Association(IsForeignKey = true, Name = "FK_Presences_Students", ThisKey = "studentId", OtherKey = "Id",
            Storage = "studentEntity")]
        public StudentEntity Student
        {
            get{ return this.studentEntity.Entity;}
            set { this.studentEntity.Entity = value; }
        }

        [Association(IsForeignKey = true, Name = "FK_Presences_Subjects", ThisKey = "subjectId", OtherKey="Id",
            Storage = "subjectEntity")]
        public SubjectEntity Subject
        {
            get { return this.subjectEntity.Entity; }
            set { this.subjectEntity.Entity = value; }

        }

        [Column(Name = "Date", CanBeNull = false)]
        public DateTime Date { get; private set; }

        [Column(Name = "Present", CanBeNull = false)]
        public bool Present { get; set; }
    }
}
