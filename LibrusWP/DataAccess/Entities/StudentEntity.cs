using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name = "Students")]
    public class StudentEntity
    {
        public StudentEntity()
        {
        }

        public StudentEntity(string name, string surname, bool gender)
        {
            this.Name = name;
            this.Surname = surname;
            this.Gender = gender;
        }

        [Column(Name = "Id", CanBeNull = false, IsDbGenerated = true, IsPrimaryKey = true)]
        public int Id { get; set; }

        [Column(Name = "Name", CanBeNull = false)]
        public string Name { get; private set; }

        [Column(Name = "Surname", CanBeNull = false)]
        public string Surname { get; private set; }

        [Column(Name = "Gender", CanBeNull = false)]
        public bool Gender { get; private set; }

        //[Column(Name = "ClassId", CanBeNull = false)]
        //public string ClassId { get; private set; }
    }
}
