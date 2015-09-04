using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public class TimeTableRepository : ITimeTableRepository
    {
        private readonly string connectionString;
        private readonly ISubjectRepository subjectRepository;
        private readonly IClassRepository classRepository;


        public TimeTableRepository(string connectionString, ISubjectRepository subjectRepository, IClassRepository classRepository)
        {
            this.connectionString = connectionString;
            this.subjectRepository = subjectRepository;
            this.classRepository = classRepository;
        }

        public IList<Model.TimeTableModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public IList<Model.TimeTableModel> GetAllByClass(string clazzId)
        {
            throw new NotImplementedException();
            //IList<TimeTableModel> timeTable = new List<TimeTableModel>();
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = @"SELECT * FROM TimeTables WHERE ClassId = @classId";
            //        cmd.Parameters.AddWithValue("@classId", clazzId);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                int id = Convert.ToInt32(reader["Id"]);
            //                string day = reader["Day"].ToString();
            //                var classIdd = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
            //                var subjectIdd = reader["SubjectId"] == DBNull.Value ? null : (object)reader["SubjectId"].ToString();
            //                ClassModel clazzz = this.classRepository.GetById(classIdd.ToString());
            //                SubjectModel sub = this.subjectRepository.GetById(subjectIdd.ToString());
            //                var  timetable = new TimeTableModel(id, day, clazzz, sub);
            //                timeTable.Add(timetable);
            //            }
            //        }

            //    }
            //}
            //return timeTable;
        }

        //dodac dodawanie id
        public void AddNew(Model.TimeTableModel model)
        {
            throw new NotImplementedException();
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "INSERT INTO TimeTables (Day, ClassId, SubjectId) VALUES(@Id, @Day, @ClassId, @SubjectId)";
            //        cmd.Parameters.AddWithValue("@Day", model.Day);
            //        cmd.Parameters.AddWithValue("@ClassId", model.Class.Id);
            //        cmd.Parameters.AddWithValue("@SubjectId", model.Subject.Id);
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        public TimeTableModel GetByClassAndSubject(string classId, string subjectId)
        {
            throw new NotImplementedException();
            //TimeTableModel timeTable = null;
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = @"SELECT * FROM TimeTables WHERE (ClassId = @classId AND SubjectId = @subjectId)";
            //        cmd.Parameters.AddWithValue("@classId", classId);
            //        cmd.Parameters.AddWithValue("@subjectId", subjectId);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                int id = Convert.ToInt32(reader["Id"]);
            //                string day = reader["Day"].ToString();
            //                var classIdd = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
            //                var subjectIdd = reader["SubjectId"] == DBNull.Value ? null : (object)reader["SubjectId"].ToString();
            //                ClassModel clazzz = this.classRepository.GetById(classIdd.ToString());
            //                SubjectModel sub = this.subjectRepository.GetById(subjectIdd.ToString());
            //                timeTable = new TimeTableModel(id, day, clazzz, sub);
            //            }
            //        }

            //    }
            //}
            //return timeTable;
        }

        public TimeTableModel GetById(int timetableId)
        {
            throw new NotImplementedException();
            //TimeTableModel timeTable = null;
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = @"SELECT * FROM TimeTables WHERE Id =@id";
            //        cmd.Parameters.AddWithValue("@id", timetableId);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                int id = Convert.ToInt32(reader["Id"]);
            //                string day = reader["Day"].ToString();
            //                var classId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
            //                var subjectId = reader["SubjectId"] == DBNull.Value ? null : (object)reader["SubjectId"].ToString();
            //                ClassModel clazzz = this.classRepository.GetById(classId.ToString());
            //                SubjectModel sub = this.subjectRepository.GetById(subjectId.ToString());
            //                timeTable = new TimeTableModel(id, day, clazzz, sub);
            //            }
            //        }

            //    }
            //}
            //return timeTable;
        }
    }
}
