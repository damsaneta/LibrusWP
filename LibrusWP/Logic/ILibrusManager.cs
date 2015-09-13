using LibrusWP.Model;
using System;
using System.Collections.Generic;
namespace LibrusWP.Logic
{
    public interface ILibrusManager
    {
        List<ClassModel> GetAllClasses(); 
        List<SubjectModel> GetAllSubjects(); 
        IList<SubjectModel> GetSubjectsForClass(ClassModel selectedClass); 
        SubjectModel GetSubjectById(string id); 
        ClassModel GetClassById(string id); 
        IList<StudentModel> GetStudentsByClass(string id); 
        TimeTableModel GetTimeTable( ClassModel clazz, SubjectModel subject);
        StudentModel GetStudentById(int fullName);
        IList<StudentModel> GetAllStudents();
        IList<TimeTableModel> GetAllTimetables();
        IList<PresenceModel> GetAllPresences();       
        IList<PresenceModel> GetPresencesByStudentAndSubject(int p1, string p2);
        TimeTableModel GetTimeTableById(int timetableId);     
        IList<PresenceModel> GetPresencesByStudentsSubjectDate(IList<StudentModel> students, SubjectModel subjectModel, DateTime dateTime);
        void SavePresences(IList<PresenceModel> list);

    }
}
