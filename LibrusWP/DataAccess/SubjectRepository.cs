using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public class SubjectRepository: ISubjectRepository
    {
        private readonly string connectionString;

        public SubjectRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public List<SubjectModel> GetAll()
        {
            throw new NotImplementedException();
            //List<SubjectModel> result = new List<SubjectModel>();
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT SubjectId, SubjectName FROM Subjects";
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var id = reader["SubjectId"].ToString();
            //                var name = reader["SubjectName"].ToString();
            //                var subject = new SubjectModel(id, name);
            //                result.Add(subject);

            //            }
            //        }
            //    }
            //}
            //return result;
        }


        public void AddNew(SubjectModel model)
        {
            throw new NotImplementedException();
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "INSERT INTO Subjects (SubjectId, SubjectName) VALUES(@Id, @Name)";
            //        cmd.Parameters.AddWithValue("@Id", model.Id);
            //        cmd.Parameters.AddWithValue("@Name", model.Name);
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        public SubjectModel GetById(string id)
        {
            throw new NotImplementedException();
            //SubjectModel subject = null;
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT * FROM Subjects WHERE SubjectId = @Id";
            //        cmd.Parameters.AddWithValue("@Id", id);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var idd = reader["SubjectId"].ToString();
            //                var name = reader["SubjectName"].ToString();
            //                subject = new SubjectModel(idd, name);
            //            }

            //        }

            //    }

            //}
            //return subject;
        }
    }
}
