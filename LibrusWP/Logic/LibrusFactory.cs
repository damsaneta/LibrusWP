using LibrusWP.DataAccess;
using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.Logic
{
    public static class LibrusFactory
    {
        private const string connectionString = @"isostore:/LibrusWP.sdf";
        private static ILibrusManager librusManager;
        private static LibrusDataContext DataContext = new LibrusDataContext(connectionString);
        private static IClassRepository classRepository;
        private static ISubjectRepository subjectRepository;
        private static ITimeTableRepository timeTableRepository;
        private static IStudentRepository studentRepository;
        private static IPresenceRepository presenceRepository;

        public static ILibrusManager CreateLibrusManager()
        {
            if(librusManager == null)
            {
                librusManager = GetManager();
            }

            return librusManager;
        }
        
        public static IClassRepository CreateClassRepository()
        {
            if (classRepository == null)
            {
                classRepository = new ClassRepository(LibrusFactory.DataContext);
            }

            return classRepository;
        }

        public static IPresenceRepository CreatePresenceRepository()
        {
            if(presenceRepository == null)
            {
                presenceRepository = new PresenceRepository(LibrusFactory.DataContext);
            }

            return presenceRepository;
        }

        public static IStudentRepository CreateStudentRepository()
        {
            if(studentRepository == null)
            {
                studentRepository = new StudentRepository(LibrusFactory.DataContext);
            }

            return studentRepository;
        }

        public static ISubjectRepository CreateSubjectRepository()
        {
            if(subjectRepository == null)
            {
                subjectRepository = new SubjectRepository(LibrusFactory.DataContext);
            }

            return subjectRepository;

        }

        public static ITimeTableRepository CreateTimeTableRepository()
        {
            if(timeTableRepository == null)
            {
                timeTableRepository = new TimeTableRepository(LibrusFactory.DataContext);
            }

            return timeTableRepository;
        }

        public static ILibrusManager GetFakeManager()
        {
            return new FakeLibrusManager();
        }

        public static ILibrusManager GetManager()
        {
            return new LibrusManager(CreateClassRepository(), CreateSubjectRepository(), CreateTimeTableRepository(),
                CreateStudentRepository(), CreatePresenceRepository());
        }

        public static void InsertTestData()
        {
            if (!DataContext.DatabaseExists())
            {
                DataContext.CreateDatabase();
                var fakeManager = GetFakeManager();
                var manager = GetManager();
                var classes = fakeManager.GetAllClasses();
                foreach (var clazz in classes)
                {
                    classRepository.AddNew(new ClassEntity(clazz.Id));
                }

                var subjects = fakeManager.GetAllSubjects();
                foreach (var subject in subjects)
                {
                    subjectRepository.AddNew(new SubjectEntity(subject.Id, subject.Name));
                }

                var students = fakeManager.GetAllStudents();
                foreach (var student in students)
                {
                    studentRepository.AddNew(new StudentEntity(student.Name, student.Surname, classRepository.GetById(student.Class.Id), student.Gender));
                }

                var timetables = fakeManager.GetAllTimetables();
                foreach(var timetable in timetables)
                {
                    timeTableRepository.AddNew(new TimeTableEntity(timetable.Day,classRepository.GetById(timetable.Class.Id), subjectRepository.GetById(timetable.Subject.Id)));
                }

                var presences = fakeManager.GetAllPresences();
                foreach(var presence in presences)
                {
                    presenceRepository.AddNew(new PresenceEntity(studentRepository.GetById(presence.Student.StudentId),subjectRepository.GetById(presence.Subject.Id),presence.Date.Date,presence.Present));
                }
           
            }
        }
    }
}
