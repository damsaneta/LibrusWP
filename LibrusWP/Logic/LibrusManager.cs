using LibrusWP.DataAccess;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.Logic
{
    public class LibrusManager : ILibrusManager
    {
        private readonly IClassRepository classRepository;
        private readonly ISubjectRepository subjectRepository;
        private readonly ITimeTableRepository timeTableRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IPresenceRepository presenceRepository;

        public LibrusManager(IClassRepository classRepository, ISubjectRepository subjectRepository, ITimeTableRepository timeTableRepository,
            IStudentRepository studentRepository, IPresenceRepository presenceRepository)
        {
            this.classRepository = classRepository;
            this.subjectRepository = subjectRepository;
            this.timeTableRepository = timeTableRepository;
            this.studentRepository = studentRepository;
            this.presenceRepository = presenceRepository;
        }

        public List<Model.ClassModel> GetAllClasses()
        {
            return this.classRepository.GetAll();
        }

        public List<Model.SubjectModel> GetAllSubjects()
        {
            return this.subjectRepository.GetAll();
        }

        public IList<SubjectModel> GetSubjectsForClass(ClassModel selectedClass)
        {
            var timeTables = this.timeTableRepository.GetAllByClass(selectedClass.Id);
            return timeTables.Select(x => x.Subject).ToList();
        }

        public SubjectModel GetSubjectById(string id)
        {
            return this.subjectRepository.GetById(id);
        }

        public ClassModel GetClassById(string id)
        {
            return this.classRepository.GetById(id);
        }

        public IList<Model.StudentModel> GetStudentsByClass(string id)
        {
            return this.studentRepository.GetAllByClass(id);
        }

        public Model.TimeTableModel GetTimeTable(Model.ClassModel clazz, Model.SubjectModel subject)
        {
            return this.timeTableRepository.GetByClassAndSubject(clazz.Id, subject.Id);
        }
  
        public Model.StudentModel GetStudentById(int id)
        {
            return this.studentRepository.GetById(id);
        }

        public IList<Model.PresenceModel> GetPresencesByStudentAndSubject(string studentId, string SubjectId)
        {
            return this.presenceRepository.GetAllByStudentAndSubject(studentId, SubjectId);
        }

        public Model.TimeTableModel GetTimeTableById(int timetableId)
        {
            return this.timeTableRepository.GetById(timetableId);
        }

        public IList<Model.PresenceModel> GetPresencesByStudentsSubjectDate(IList<Model.StudentModel> students, Model.SubjectModel subjectModel, DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public void SavePresences(IList<Model.PresenceModel> list)
        {
            throw new NotImplementedException();
        }
    }
}
