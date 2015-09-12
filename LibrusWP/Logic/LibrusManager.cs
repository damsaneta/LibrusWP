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

        public IList<SubjectModel> GetSubjectsForClass(ClassModel selectedClass)
        {
            
            var timeTables = this.timeTableRepository.GetAllByClass(selectedClass.Id);
            IList<SubjectEntity> subjects =  timeTables.Select(x => x.Subject).ToList();
            IList<SubjectModel> result = subjects.Select(x => new SubjectModel(x.Id, x.Name)).ToList();
            return result;

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

        public IList<StudentModel> GetStudentsByClass(string id)
        {
            var students = this.studentRepository.GetAllByClass(id);
            return students.Select(x => new StudentModel(x.Id, x.Name, x.Surname, new ClassModel(x.Class.Id),x.Gender))
                .OrderBy(x => x.Surname).ThenBy(x => x.Name).ToList();
        }

        public TimeTableModel GetTimeTable(ClassModel clazz, SubjectModel subject)
        {
            TimeTableEntity timetable = this.timeTableRepository.GetByClassAndSubject(clazz.Id, subject.Id);
            return new TimeTableModel(timetable.Id, timetable.Day, new ClassModel(timetable.Class.Id),
                new SubjectModel(timetable.Subject.Id, timetable.Subject.Name));
        }
  
        public StudentModel GetStudentById(int id)
        {
            StudentEntity student = this.studentRepository.GetById(id); 
            return new StudentModel(student.Id, student.Name, student.Surname, new ClassModel(student.Class.Id)
                , student.Gender);
            
        }
        
        public IList<PresenceModel> GetPresencesByStudentAndSubject(int studentId, string subjectId)
        {
            IList<PresenceEntity> presences = this.presenceRepository.GetAllByStudentAndSubject(studentId, subjectId);
            var student = this.GetStudentById(studentId);
            var subject = this.GetSubjectById(subjectId);
            return presences.Select(x => new PresenceModel(student, subject, x.Date, x)).ToList();
        }

        public TimeTableModel GetTimeTableById(int timetableId)
        {
            TimeTableEntity timetable = this.timeTableRepository.GetById(timetableId);
            return new TimeTableModel(timetable.Id,timetable.Day, new ClassModel(timetable.Class.Id)
                , new SubjectModel(timetable.Subject.Id, timetable.Subject.Name));
        }
 
        public IList<PresenceModel> GetPresencesByStudentsSubjectDate(IList<StudentModel> students, SubjectModel subjectModel, DateTime dateTime)
        {
            IList<PresenceModel> list = new List<PresenceModel>();
            foreach(StudentModel student in students)
            {
                PresenceEntity presence = this.presenceRepository.GetByStudentAndSubjectAndDate(student.StudentId, subjectModel.Id, dateTime);
                list.Add(new PresenceModel(student, subjectModel, dateTime, presence));
            }

            return list;
        }
     
        public void SavePresences(IList<PresenceModel> list)
        {
            foreach(var model in list)
            {
                if(model.Id != 0)
                {
                    presenceRepository.Update(model.Id, model.Present);
                }
                else
                {
                    var student = this.studentRepository.GetById(model.Student.StudentId);
                    var subject = this.subjectRepository.GetById(model.Subject.Id);
                    var entity = new PresenceEntity(student, subject, model.Date, model.Present);
                    presenceRepository.AddNew(entity);
                }

            }
        
        }


        public IList<StudentModel> GetAllStudents()
        {
            IList<StudentEntity> students = studentRepository.GetAll();
            return students.Select(x => new StudentModel(x.Id, x.Name, x.Surname, new ClassModel(x.Class.Id),x.Gender))
                .OrderBy(x=> x.Surname).ThenBy(x => x.Name).ToList();

        }

        public IList<TimeTableModel> GetAllTimetables()
        {
            IList<TimeTableEntity> timetables = timeTableRepository.GetAll();
            return timetables.Select(x => new TimeTableModel(x.Id, x.Day, new ClassModel(x.Class.Id)
                , new SubjectModel(x.Subject.Id, x.Subject.Name))).ToList();
        }

        public IList<PresenceModel> GetAllPresences()
        {
            IList<PresenceEntity> presences = presenceRepository.GetAll();
            return presences.Select(x => new PresenceModel(new StudentModel(x.Student.Id, x.Student.Name, x.Student.Surname, new ClassModel(x.Student.Class.Id), x.Student.Gender)
                , new SubjectModel(x.Subject.Id, x.Subject.Name), x.Date.Date, x)).ToList();
        }
    }
}
