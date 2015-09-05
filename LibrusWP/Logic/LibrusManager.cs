using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;
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
            IList<ClassEntity> all = this.classRepository.GetAll();
            var result = all.Select(x => new ClassModel(x.Id)).ToList();
            return result;
        }

        public List<Model.SubjectModel> GetAllSubjects()
        {
            IList<SubjectEntity> all = this.subjectRepository.GetAll();
            var result = all.Select(x => new SubjectModel(x.Id, x.Name)).ToList();
            return result;
        }
        // TO DO
        public IList<SubjectModel> GetSubjectsForClass(ClassModel selectedClass)
        {
           
            //var timeTables = this.timeTableRepository.GetAllByClass(selectedClass.Id);
            //return timeTables.Select(x => x.Subject).ToList();
            return null;
        }

        public SubjectModel GetSubjectById(string id)
        {
            SubjectEntity subject = this.subjectRepository.GetById(id);
            return new SubjectModel(subject.Id, subject.Name);
        }

        public ClassModel GetClassById(string id)
        {
            ClassEntity clazz = this.classRepository.GetById(id);
            return new ClassModel(clazz.Id);
        }
        // TO DO
        public IList<StudentModel> GetStudentsByClass(string id)
        {
            //return this.studentRepository.GetAllByClass(id);
            return null;
        }

        //TODO
        public TimeTableModel GetTimeTable(Model.ClassModel clazz, Model.SubjectModel subject)
        {
            return null;
           // return this.timeTableRepository.GetByClassAndSubject(clazz.Id, subject.Id);
        }
  
        public StudentModel GetStudentById(int id)
        {
            // TO DO: dodać klasę, zamiast nulla
            StudentEntity student = this.studentRepository.GetById(id); 
            return new StudentModel(student.Id, student.Name, student.Surname, null, student.Gender);
            
        }
        //TODO
        public IList<Model.PresenceModel> GetPresencesByStudentAndSubject(string studentId, string subjectId)
        {
            this.presenceRepository.GetAllByStudentAndSubject(studentId, subjectId);
            return null;
            
        }
        //TODO
        public TimeTableModel GetTimeTableById(int timetableId)
        {
            TimeTableEntity timetable = this.timeTableRepository.GetById(timetableId);
            return null;
        }
        //TODO
        public IList<Model.PresenceModel> GetPresencesByStudentsSubjectDate(IList<Model.StudentModel> students, Model.SubjectModel subjectModel, DateTime dateTime)
        {
            throw new NotImplementedException();
        }
        //TODO
        public void SavePresences(IList<Model.PresenceModel> list)
        {
            throw new NotImplementedException();
        }
    }
}
