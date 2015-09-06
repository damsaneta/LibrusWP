using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name = "Students")]
    public class StudentEntity
    {
        [Column(Name = "ClassId", CanBeNull = false)]
        private string classId;
        private EntityRef<ClassEntity> classEntity = new EntityRef<ClassEntity>();

        public StudentEntity()
        {
        }

        public StudentEntity(string name, string surname, ClassEntity clazz, bool gender)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
            this.Class = clazz;
        }

        [Column(Name = "Id", CanBeNull = false, IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "Name", CanBeNull = false)]
        public string Name { get; private set; }

        [Column(Name = "Surname", CanBeNull = false)]
        public string Surname { get; private set; }

        [Column(Name = "Gender", CanBeNull = false)]
        public bool Gender { get; private set; }

        [Association(IsForeignKey = true, Name = "FK_Students_Classes", ThisKey = "classId",
            OtherKey = "Id", Storage = "classEntity")]
        public ClassEntity Class
        {
            get { return this.classEntity.Entity; }
            set { this.classEntity.Entity = value; }
        }
    }
}
