using LibrusWP.Logic;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.ViewModels
{
    public class InformationAboutPresencesViewModel
    {
        private readonly ILibrusManager manager;

        public InformationAboutPresencesViewModel(ILibrusManager manager, int studentId, string subjectId)
        {
            this.manager = manager;
            this.Subject = this.manager.GetSubjectById(subjectId);
            this.Student = this.manager.GetStudentById(studentId);
            this.Presences = this.manager.GetPresencesByStudentAndSubject(this.Student.StudentId, this.Subject.Id);
        }


        public IList<PresenceModel> Presences { get; private set; }

        public StudentModel Student { get; private set; }

        public SubjectModel Subject { get; private set; }

    }
}
