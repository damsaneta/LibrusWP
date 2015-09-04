using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LibrusWP.Model;
using LibrusWP.DataAccess;
using System.Linq;

namespace LibrusWP.Tests
{
    [TestClass]
    public class DatabaseTests
    {
        private readonly string connString = @"Data Source=D:\Users\aneta\Desktop\LibrusWP\LibrusWP.Tests\Databases\SqlLiteDatabase.sqlite;Version=3";
       
        [TestMethod]
        public void Insert_into_test_table_test()
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using(var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Test (Name) VALUES('aaaa')";
                    cmd.ExecuteNonQuery();
                }
            }
        }

        [TestMethod]
        public void Select_from_test_table_test()
        {
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Test WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("@Id", 1);
                    using(var reader = cmd.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            var id = reader["Id"].ToString();
                            var name = reader["Name"].ToString();
                        }
                    }
                }
            }
        }
        [TestMethod]
        public void AddClass() // ClassModel clazz
        {
            //this.AddNewClass(new ClassModel("IC"));
           // var r = this.GetAllClasses();
          var t = this.GetClassById("IA");
           // this.AddNewSubject(new SubjectModel("MD", "Matematyka Dyskretna"));
           // var t = this.GetSubjectById("MD");
           // var t = this.GetAllSubjects();
           // this.AddNewStudent(new StudentModel("Aneta", "Dams", t, true));
         //   this.AddNewStudent(new StudentModel("Karolina", "Kowalska", t, true));
           // this.AddNewStudent(new StudentModel("Anna", "Nowak", t, true));
          // var g = this.GetStudentByFullName("Nowak Anna");
          //  var t = this.GetStudentsByClass("IA");
            var date = "środa";
           // var t =new TimeTableModel(1, date, this.GetClassById("IA"), this.GetSubjectById("AM"));
          // this.AddNewTimeTable(new TimeTableModel(2, date, this.GetClassById("IB"), this.GetSubjectById("AiSD")));
           // this.AddNewTimeTable(t);
           // var t = this.GetTimeTable(this.GetClassById("IB"), this.GetSubjectById("AiSD"));
           // var t = this.GetTimeTableById(2);
            var tee = this.GetSubjects(t);
        }
        [TestMethod]
        public void AddNewClass(ClassModel clazz)
        {
           
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Classes (ClassId, ClassName) VALUES(@Id, @Name)";
                    cmd.Parameters.AddWithValue("@Id", clazz.Id);
                    cmd.Parameters.AddWithValue("@Name", clazz.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
     
        public List<ClassModel> GetAllClasses()
        {
            List<ClassModel> result = new List<ClassModel>();
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT ClassId FROM Classes";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["ClassId"].ToString();
                            var clazz = new ClassModel(id);
                            result.Add(clazz);

                        }
                    }
                }
            }
            return result;
        }
        public ClassModel GetClassById(string id)
        {
            ClassModel clazz = null;
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Classes WHERE ClassId = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var idd = reader["ClassId"].ToString();
                            clazz = new ClassModel(idd);
                        }

                    }

                }

            }
            return clazz;
        }
        IList<SubjectModel> GetSubjects(ClassModel selectedClass)
        {
           
            var timetable = this.GetAllTimeTable();
             return timetable.Where(x => x.Class.Id == selectedClass.Id)
               .Select(x => x.Subject)
               .ToList();
 
        }
        //repozytorium klas
        public void AddNewSubject(SubjectModel subject)
        {

            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "INSERT INTO Subjects (SubjectId, SubjectName) VALUES(@Id, @Name)";
                    cmd.Parameters.AddWithValue("@Id", subject.Id);
                    cmd.Parameters.AddWithValue("@Name", subject.Name);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<SubjectModel> GetAllSubjects()
        {
            List<SubjectModel> result = new List<SubjectModel>();
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT SubjectId, SubjectName FROM Subjects";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var id = reader["SubjectId"].ToString();
                            var name = reader["SubjectName"].ToString();
                            var subject = new SubjectModel(id, name);
                            result.Add(subject);

                        }
                    }
                }
            }
            return result;
        }
        public SubjectModel GetSubjectById(string id)
        {
            SubjectModel subject = null;
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM Subjects WHERE SubjectId = @Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var idd = reader["SubjectId"].ToString();
                            var name = reader["SubjectName"].ToString();
                            subject = new SubjectModel(idd, name);
                        }

                    }

                }

            }
            return subject;
        }
        //uzytkownicy
        public void AddNewStudent(StudentModel user)
        {
            var student = user as StudentModel;
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Students (Name, Surname, Gender, ClassId) 
                        VALUES (@name, @surname, @gender, @classId)";
                    cmd.Parameters.AddWithValue("@name", user.Name);
                    cmd.Parameters.AddWithValue("@surname", user.Surname);
                    int gen = (user.Gender)? 1 : 0;
                    cmd.Parameters.AddWithValue("@gender", gen);
                    cmd.Parameters.AddWithValue("@classId", student != null ? (object)student.Class.Id : DBNull.Value);
                    cmd.ExecuteNonQuery();
                   
                }
            }

        }
         StudentModel GetStudentByFullName(string fullName)
        {
            StudentModel user = null;
            string[] tab = fullName.Split(new char[] { ' ' });
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM Students WHERE (Name = @name AND Surname = @surname)";
                    cmd.Parameters.AddWithValue("@surname", tab[0]);
                    cmd.Parameters.AddWithValue("@name", tab[1]);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var surname = reader["Surname"].ToString();
                            var name = reader["Name"].ToString();
                            var gen = reader["Gender"];
                            bool gender = Convert.ToBoolean(gen);
                            var classId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
                            ClassModel clazz = this.GetClassById(classId.ToString());
                            user = new StudentModel(name, surname, clazz, gender);
                        }
                    }

                }
            }
            return user;
        }
         IList<StudentModel> GetStudentsByClass(string id)
         {
             IList<StudentModel> list = new List<StudentModel>();
             using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
             {
                 connection.Open();
                 using (var cmd = connection.CreateCommand())
                 {
                     cmd.CommandText = @"SELECT * FROM Students WHERE ClassId = @id";
                     cmd.Parameters.AddWithValue("@id", id);
                     using (var reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             var surname = reader["Surname"].ToString();
                             var name = reader["Name"].ToString();
                             var gen = reader["Gender"];
                             bool gender = Convert.ToBoolean(gen);
                             var classId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
                             ClassModel clazz = this.GetClassById(classId.ToString());
                             var user = new StudentModel(name, surname, clazz, gender);
                             list.Add(user);
                         }
                     }

                 }
             }
             return list;
         }
        //repozytorium Timetable
         public void AddNewTimeTable(TimeTableModel timetable)
         {

             using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
             {
                 connection.Open();
                 using (var cmd = connection.CreateCommand())
                 {
                     cmd.CommandText = "INSERT INTO TimeTables (Day, ClassId, SubjectId) VALUES(@Id, @Day, @ClassId, @SubjectId)";
                     cmd.Parameters.AddWithValue("@Day", timetable.Day);
                     cmd.Parameters.AddWithValue("@ClassId", timetable.Class.Id);
                     cmd.Parameters.AddWithValue("@SubjectId", timetable.Subject.Id);
                     cmd.ExecuteNonQuery();
                 }
             }
         }
         TimeTableModel GetTimeTable(ClassModel clazz, SubjectModel subject)
         {
             TimeTableModel timeTable = null;
             using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
             {
                 connection.Open();
                 using (var cmd = connection.CreateCommand())
                 {
                     cmd.CommandText = @"SELECT * FROM TimeTables WHERE (ClassId = @classId AND SubjectId = @subjectId)";
                     cmd.Parameters.AddWithValue("@classId", clazz.Id);
                     cmd.Parameters.AddWithValue("@subjectId", subject.Id);
                     using (var reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             int id = Convert.ToInt32(reader["Id"]);
                             string day = reader["Day"].ToString();
                             var classId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
                             var subjectId = reader["SubjectId"] == DBNull.Value ? null : (object)reader["SubjectId"].ToString();
                             ClassModel clazzz = this.GetClassById(classId.ToString());
                             SubjectModel sub = this.GetSubjectById(subjectId.ToString());
                             timeTable = new TimeTableModel(id, day, clazzz, sub);
                         }
                     }

                 }
             }
             return timeTable;
         }
        TimeTableModel GetTimeTableById(int timetableId)
         {
             TimeTableModel timeTable = null;
             using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
             {
                 connection.Open();
                 using (var cmd = connection.CreateCommand())
                 {
                     cmd.CommandText = @"SELECT * FROM TimeTables WHERE Id =@id";
                     cmd.Parameters.AddWithValue("@id", timetableId);
                     using (var reader = cmd.ExecuteReader())
                     {
                         while (reader.Read())
                         {
                             int id = Convert.ToInt32(reader["Id"]);
                             string day = reader["Day"].ToString();
                             var classId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
                             var subjectId = reader["SubjectId"] == DBNull.Value ? null : (object)reader["SubjectId"].ToString();
                             ClassModel clazzz = this.GetClassById(classId.ToString());
                             SubjectModel sub = this.GetSubjectById(subjectId.ToString());
                             timeTable = new TimeTableModel(id, day, clazzz, sub);
                         }
                     }

                 }
             }
             return timeTable;
         }
        IList<TimeTableModel> GetAllTimeTable()
        {
           IList<TimeTableModel> timeTable = new List<TimeTableModel>();
            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connString))
            {
                connection.Open();
                using (var cmd = connection.CreateCommand())
                {
                    cmd.CommandText = @"SELECT * FROM TimeTables";
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["Id"]);
                            string day = reader["Day"].ToString();
                            var classId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
                            var subjectId = reader["SubjectId"] == DBNull.Value ? null : (object)reader["SubjectId"].ToString();
                            ClassModel clazzz = this.GetClassById(classId.ToString());
                            SubjectModel sub = this.GetSubjectById(subjectId.ToString());
                            var  timetable = new TimeTableModel(id, day, clazzz, sub);
                            timeTable.Add(timetable);
                        }
                    }

                }
            }
            return timeTable;
        }
      

    }
}