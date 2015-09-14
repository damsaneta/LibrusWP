using LibrusWP.Logic;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.ViewModels
{
    public class StudentsListPageViewModel
    {
        private ILibrusManager manager;
        private string a;

        public StudentsListPageViewModel(ILibrusManager manager, string clazz, string subject)
        {
            this.manager = manager;
            this.Subject = this.manager.GetSubjectById(subject);
            this.Class = this.manager.GetClassById(clazz);
            this.Students = manager.GetStudentsByClass(this.Class.Id);
        }

        public IList<StudentModel> Students { get; private set; }

        public SubjectModel Subject { get; private set; }

        public ClassModel Class { get; private set; }

    }
}
