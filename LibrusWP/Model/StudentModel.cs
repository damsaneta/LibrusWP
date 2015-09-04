using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.Model
{
    public class StudentModel
    {
        public StudentModel(string name, string surname, ClassModel clazz, bool gender)
        {
            this.Name = name;
            this.Surname = surname;
            this.Class = clazz;
            this.Gender = gender;
        }

        public StudentModel(int studentId, string name, string surname, ClassModel clazz, bool gender)
            : this(name, surname, clazz, gender)
        {
            this.StudentId = studentId;
        }

        public int StudentId { get; set; }

        public string Name { get; private set; }

        public string Surname { get; private set; }
        //true woman, false man
        public bool Gender { get; private set; }

        public string FullName { get { return this.Surname + " " + this.Name; } }

        public ClassModel Class { get; private set; }
    }
}
