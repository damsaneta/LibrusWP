using LibrusWP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.Logic
{
    public static class LibrusFactory
    {
        private static ILibrusManager librusManager;
        private static string ConnectionString = "";
        private static IClassRepository classRepository;
        private static ISubjectRepository subjectRepository;
        private static ITimeTableRepository timeTableRepository;
        private static IStudentRepository studentRepository;
        private static IPresenceRepository presenceRepository;
        public static ILibrusManager CreateLibrusManager()
        {
            if(librusManager == null)
            {
                librusManager = GetFakeManager();
            }

            return librusManager;
        }
        
        public static IClassRepository CreateClassRepository()
        {
            if (classRepository == null)
            {
                classRepository = new ClassRepository(LibrusFactory.ConnectionString);
            }

            return classRepository;
        }

        public static IPresenceRepository CreatePresenceREpository()
        {
            if(presenceRepository == null)
            {
                presenceRepository = new PresenceRepository(ConnectionString);
            }

            return presenceRepository;
        }

        public static IStudentRepository CreateStudentRepository()
        {
            if(studentRepository == null)
            {
                studentRepository = new StudentRepository(ConnectionString, CreateClassRepository());
            }

            return studentRepository;
        }

        public static ISubjectRepository CreateSubjectRepository()
        {
            if(subjectRepository == null)
            {
                subjectRepository = new SubjectRepository(LibrusFactory.ConnectionString);
            }

            return subjectRepository;

        }

        public static ITimeTableRepository CreateTimeTableRepository()
        {
            if(timeTableRepository == null)
            {
                timeTableRepository = new TimeTableRepository(LibrusFactory.ConnectionString, CreateSubjectRepository(), CreateClassRepository());
            }
            return timeTableRepository;
        }

        private static ILibrusManager GetFakeManager()
        {
            return new FakeLibrusManager();
        }

        private static ILibrusManager GetManager()
        {
            return new LibrusManager(CreateClassRepository(), CreateSubjectRepository(), CreateTimeTableRepository(),
                CreateStudentRepository(), CreatePresenceREpository());
        }
    }
}
