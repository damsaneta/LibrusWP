using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public class StudentRepository: IStudentRepository
    {
        private readonly string connectionString;

        private readonly IClassRepository classRepository;

        public StudentRepository(string connectionString, IClassRepository classRepository)
        {
            this.connectionString = connectionString;
            this.classRepository = classRepository;
        }

        public IList<StudentModel> GetAll()
        {
            throw new NotImplementedException();
        }


        public IList<StudentModel> GetAllByClass(string classId)
        {
            throw new NotImplementedException();
            //IList<StudentModel> list = new List<StudentModel>();
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = @"SELECT * FROM Students WHERE ClassId = @id";
            //        cmd.Parameters.AddWithValue("@id", classId);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var id = Convert.ToInt32(reader["Id"]);
            //                var surname = reader["Surname"].ToString();
            //                var name = reader["Name"].ToString();
            //                var gen = reader["Gender"];
            //                bool gender = Convert.ToBoolean(gen);
            //                var clazzId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
            //                ClassModel clazz = this.classRepository.GetById(clazzId.ToString());
            //                var user = new StudentModel(id, name, surname, clazz, gender);
            //                list.Add(user);
            //            }
            //        }

            //    }
            //}
            //return list;
        }

        public void AddNew(StudentModel model)
        {
            throw new NotImplementedException();
//            var student = model as StudentModel;
//            using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
//            {
//                connection.Open();
//                using (var cmd = connection.CreateCommand())
//                {
//                    cmd.CommandText = @"INSERT INTO Students (Name, Surname, Gender, ClassId) 
//                        VALUES (@name, @surname, @gender, @classId)";
//                    cmd.Parameters.AddWithValue("@name", model.Name);
//                    cmd.Parameters.AddWithValue("@surname", model.Surname);
//                    int gen = (model.Gender) ? 1 : 0;
//                    cmd.Parameters.AddWithValue("@gender", gen);
//                    cmd.Parameters.AddWithValue("@classId", student != null ? (object)student.Class.Id : DBNull.Value);
//                    cmd.ExecuteNonQuery();

//                }
//            }
        }
        //id jest intem trzeba zmienic
        public StudentModel GetById(int id)
        {
            throw new NotImplementedException();
            //StudentModel user = null;
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = @"SELECT * FROM Students WHERE Id = @id";
            //        cmd.Parameters.AddWithValue("@id", id);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var studentId = Convert.ToInt32(reader["Id"]);
            //                var surname = reader["Surname"].ToString();
            //                var name = reader["Name"].ToString();
            //                var gen = reader["Gender"];
            //                bool gender = Convert.ToBoolean(gen);
            //                var classId = reader["ClassId"] == DBNull.Value ? null : (object)reader["ClassId"].ToString();
            //                ClassModel clazz = this.classRepository.GetById(classId.ToString());
            //                user = new StudentModel(id , name, surname, clazz, gender);
            //            }
            //        }

            //    }
            //}
            //return user;
        }
    }
}
