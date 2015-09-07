using LibrusWP.Model;
using System;
using System.Collections.Generic;
namespace LibrusWP.Logic
{
    public interface ILibrusManager
    {
        List<ClassModel> GetAllClasses(); //done
        List<SubjectModel> GetAllSubjects(); //done
        IList<SubjectModel> GetSubjectsForClass(ClassModel selectedClass); // done
        SubjectModel GetSubjectById(string id); // done
        ClassModel GetClassById(string id); //done
        IList<StudentModel> GetStudentsByClass(string id); // done
        TimeTableModel GetTimeTable( ClassModel clazz, SubjectModel subject);// done
        StudentModel GetStudentById(int fullName);//done
        IList<StudentModel> GetAllStudents();
        IList<TimeTableModel> GetAllTimetables();
        IList<PresenceModel> GetAllPresences();
        
        IList<PresenceModel> GetPresencesByStudentAndSubject(int p1, string p2);
        TimeTableModel GetTimeTableById(int timetableId);//done
        //IList<TimeTableModel> GetTimeTableBySubjectAndClass(SubjectModel subjectModel, ClassModel classModel);// niepotrzebne
        IList<PresenceModel> GetPresencesByStudentsSubjectDate(IList<StudentModel> students, SubjectModel subjectModel, DateTime dateTime);
        void SavePresences(IList<PresenceModel> list);
       

        //DateTime FindLastPresencesByClassAndSubject(string p1, string p2);
    }
}
