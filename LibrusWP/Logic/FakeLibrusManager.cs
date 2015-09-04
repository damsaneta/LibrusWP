using LibrusWP.DataAccess;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.Logic
{
    public class FakeLibrusManager : ILibrusManager
    {
        private readonly IList<TimeTableModel> timeTable = new List<TimeTableModel>();
        private readonly IList<ClassModel> classes = new List<ClassModel>();
        private readonly IList<StudentModel> students = new List<StudentModel>();
        private readonly IList<SubjectModel> subjects = new List<SubjectModel>();
        private readonly IList<PresenceModel> presences = new List<PresenceModel>();
        private readonly IClassRepository classRepository;

        public FakeLibrusManager()
        {
            
            this.classes.Add(new ClassModel("IA"));
            this.classes.Add(new ClassModel("IB"));
            this.classes.Add(new ClassModel("IC"));

            var clazz = this.GetClassById("IA");
            this.students.Add(new StudentModel(1,"Aneta", "Dams", clazz, true));
            this.students.Add(new StudentModel(2,"Karolina", "Kowalska", clazz, true));
            this.students.Add(new StudentModel(3,"Anna", "Nowak", clazz, true));
            this.students.Add(new StudentModel(4,"Mateusz", "Brzeziński", clazz, false));
            this.students.Add(new StudentModel(5,"Justyna", "Karpińska", clazz, true));
            var clazz1 = this.GetClassById("IB");
            this.students.Add(new StudentModel(6,"Maciej", "Sikorski", clazz1, false));
            this.students.Add(new StudentModel(7,"Paweł", "Nowakowski", clazz1, false));
            this.students.Add(new StudentModel(8,"Adrian", "Rydzyński", clazz1, false));
            this.students.Add(new StudentModel(9,"Monika", "Kwiatkowska", clazz1, true));
            var clazz2 = this.GetClassById("IC");
            this.students.Add(new StudentModel(10,"Anna", "Mrozowska", clazz2, true));
            this.students.Add(new StudentModel(11,"Kamila", "Boruta", clazz2, true));
            this.students.Add(new StudentModel(12,"Anrzej", "Gutowski", clazz2, false));
            this.students.Add(new StudentModel(13,"Szymon", "Kołodziej", clazz2, false));

            
            this.subjects.Add(new SubjectModel("AM", "Analiza Matematyczna"));
            this.subjects.Add(new SubjectModel("MD", "Matematyka Dyskretna"));
            this.subjects.Add(new SubjectModel("AiSD", "Algorytmy i struktury danych"));
            this.subjects.Add(new SubjectModel("SO", "Systemy Operacyjne"));

            this.subjects.Add(new SubjectModel("PI", "Programowanie I (C++)"));
            this.subjects.Add(new SubjectModel("AL", "Algebra Liniowa"));
            this.subjects.Add(new SubjectModel("SOS", "Środowisko Obliczeń Symblicznych"));
            this.subjects.Add(new SubjectModel("TJF", "Teoria Języków Formalnych"));
            this.subjects.Add(new SubjectModel("PII", "Programowanie II (C#)"));
            this.subjects.Add(new SubjectModel("PB", "Projekt Bazodanowy"));
            this.subjects.Add(new SubjectModel("LG", "Laboratorium Grafiki"));
            this.subjects.Add(new SubjectModel("PIII", "Programowanie III (Java)"));
            this.subjects.Add(new SubjectModel("TO", "Teoria Obliczalności"));
            int id = 0;
            Random gen = new Random();
                id++;
                var date = "środa";
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IA"), this.GetSubjectById("AM")));
                var start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++ )
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id),d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IB"), this.GetSubjectById("AiSD")));
                 start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IC"), this.GetSubjectById("AL")));
                 start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IA"), this.GetSubjectById("MD")));
                start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IB"), this.GetSubjectById("SO")));
                start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IC"), this.GetSubjectById("SOS")));
                start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
  
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IA"), this.GetSubjectById("SO")));
                start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IB"), this.GetSubjectById("TJF")));
                start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date, this.GetClassById("IC"), this.GetSubjectById("PB")));
                start = new DateTime(2014, 10, 1, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
     
                id++;
                var date1 = "czwartek";
                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IA"), this.GetSubjectById("PI")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IB"), this.GetSubjectById("PII")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IC"), this.GetSubjectById("AiSD")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;

                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IA"), this.GetSubjectById("AL")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IB"), this.GetSubjectById("PB")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IC"), this.GetSubjectById("PI")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;

                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IA"), this.GetSubjectById("PB")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IB"), this.GetSubjectById("SOS")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date1, this.GetClassById("IC"), this.GetSubjectById("AM")));
                start = new DateTime(2014, 10, 2, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
           
                id++;
                var date2 = "piątek";
                this.timeTable.Add(new TimeTableModel(id, date2, this.GetClassById("IA"), this.GetSubjectById("AiSD")));
                start = new DateTime(2014, 10, 3, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date2, this.GetClassById("IB"), this.GetSubjectById("PI")));
                start = new DateTime(2014, 10, 3, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date2, this.GetClassById("IC"), this.GetSubjectById("PIII")));
                start = new DateTime(2014, 10, 3, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;

                this.timeTable.Add(new TimeTableModel(id, date2, this.GetClassById("IA"), this.GetSubjectById("TJF")));
                start = new DateTime(2014, 10, 3, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date2, this.GetClassById("IB"), this.GetSubjectById("AM")));
                start = new DateTime(2014, 10, 3, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date2, this.GetClassById("IC"), this.GetSubjectById("LG")));
                start = new DateTime(2014, 10, 3, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
        
                id++;
                var date3 = "poniedziałek";
                this.timeTable.Add(new TimeTableModel(id, date3, this.GetClassById("IA"), this.GetSubjectById("LG")));
                start = new DateTime(2014, 10, 6, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date3, this.GetClassById("IB"), this.GetSubjectById("AL")));
                start = new DateTime(2014, 10, 6, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date3, this.GetClassById("IC"), this.GetSubjectById("MD")));
                start = new DateTime(2014, 10, 6, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;

                this.timeTable.Add(new TimeTableModel(id, date3, this.GetClassById("IA"), this.GetSubjectById("PIII")));
                start = new DateTime(2014, 10, 6, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date3, this.GetClassById("IB"), this.GetSubjectById("TO")));
                start = new DateTime(2014, 10, 6, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date3, this.GetClassById("IC"), this.GetSubjectById("SO")));
                start = new DateTime(2014, 10, 6, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;

            
         
                id++;
                var date4 = "wtorek";
                this.timeTable.Add(new TimeTableModel(id, date4, this.GetClassById("IA"), this.GetSubjectById("TO")));
                start = new DateTime(2014, 10, 7, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date4, this.GetClassById("IB"), this.GetSubjectById("PIII")));
                start = new DateTime(2014, 10, 7, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date4, this.GetClassById("IC"), this.GetSubjectById("LG")));
                start = new DateTime(2014, 10, 7, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;

                this.timeTable.Add(new TimeTableModel(id, date4, this.GetClassById("IA"), this.GetSubjectById("SOS")));
                start = new DateTime(2014, 10, 7, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IA"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date4, this.GetClassById("IB"), this.GetSubjectById("LG")));
                start = new DateTime(2014, 10, 7, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IB"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }
                id++;
                this.timeTable.Add(new TimeTableModel(id, date4, this.GetClassById("IC"), this.GetSubjectById("TO")));
                start = new DateTime(2014, 10, 7, 8, 0, 0).Date;
                for (int t = 0; t < 9; t++)
                {
                    var d = start.AddDays(7 * t);
                    foreach (StudentModel student in this.GetStudentsByClass("IC"))
                    {
                        PresenceModel pre = new PresenceModel(student, this.GetTimeTableById(id), d);

                        int prob = gen.Next(100);
                        if (prob < 80)
                            pre.Present = true;
                        else
                            pre.Present = false;
                        this.presences.Add(pre);
                    }
                }

            
        }


        public List<ClassModel> GetAllClasses()
        {           
            return this.classes.ToList();
        }
        public List<SubjectModel> GetAllSubjects()
        {         
            return this.subjects.ToList();
        }

        public SubjectModel GetSubjectById(string id)
        {
            SubjectModel subject = this.subjects.FirstOrDefault(x => x.Id == id);
            return subject;
        }
        public ClassModel GetClassById(string id)
        {
            ClassModel clazz = this.classes.FirstOrDefault(x => x.Id == id);
            return clazz;
        }

        public StudentModel GetStudentById(int id)
        {
            return this.students.FirstOrDefault(x => x.StudentId == id);
        }

        public IList<SubjectModel> GetSubjectsForClass(ClassModel selectedClass)
        {
            return this.timeTable.Where(x => x.Class.Id == selectedClass.Id)
                .Select(x => x.Subject)
                .ToList();
        }

        public IList<StudentModel> GetStudentsByClass(string id)
        {
            return this.students.Where(x=> x.Class.Id==id).OrderBy(x => x.FullName).ToList();
        }
       
        public IList<PresenceModel> GetPresencesByStudentAndSubject(string fullName, string SubjectId)
        {
            return this.presences.Where(x => x.Student.FullName == fullName && x.TimeTable.Subject.Id== SubjectId).ToList();
        }
        public TimeTableModel GetTimeTableById(int timetableId)
        {
            return this.timeTable.FirstOrDefault(x => x.Id == timetableId);
        }

        //public IList<TimeTableModel> GetTimeTableBySubjectAndClass(SubjectModel subjectModel, ClassModel classModel)
        //{
        //    return this.timeTable.Where(x => x.Subject.Id == subjectModel.Id && x.Class.Id == classModel.Id).ToList();
        //}


        public void SavePresences(IList<PresenceModel> list)
        {

            foreach (PresenceModel c in list)
            {
                if (this.presences.Where(x => x.Date.Date == c.Date.Date && x.TimeTable.Subject.Id == c.TimeTable.Subject.Id && x.Student.FullName == c.Student.FullName).FirstOrDefault() == null)
                {
                    this.presences.Add(c);
                }
            }
        }


        public IList<PresenceModel> GetPresencesByStudentsSubjectDate(IList<StudentModel> students, SubjectModel subjectModel, DateTime dateTime)
        {
            IList<PresenceModel> list = new List<PresenceModel>();
            foreach (StudentModel s in students)
            {
                var p = this.presences.Where(x => x.Student.FullName == s.FullName && x.TimeTable.Subject.Id == subjectModel.Id && x.Date.Date == dateTime.Date).FirstOrDefault();
                if (p != null)
                {
                    list.Add(p);
                }
            }
            return list.ToList();
        }


        public TimeTableModel GetTimeTable(ClassModel clazz, SubjectModel subject)
        {
           return this.timeTable.Where(x => x.Class.Id == clazz.Id && x.Subject.Id == subject.Id).FirstOrDefault();
        }


        //public DateTime FindLastPresencesByClassAndSubject(string p1, string p2)
        //{
        //    ClassModel clazz = this.GetClassById(p1);
        //    SubjectModel subject= this.GetSubjectById(p2);
        //    return this.presences.Where(x => x.TimeTable.Class.Id == clazz.Id && x.TimeTable.Subject.Id == subject.Id).LastOrDefault().Date.Date.AddDays(7);
        //}
    }
}
