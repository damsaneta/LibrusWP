using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrusWP.DataAccess
{
    public class ClassRepository : IClassRepository
    {
        private readonly string connectionString;

        public ClassRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<ClassModel> GetAll()
        {
            throw new NotImplementedException();
            //List<ClassModel> result = new List<ClassModel>();
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT ClassId FROM Classes";
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var id = reader["ClassId"].ToString();
            //                var clazz = new ClassModel(id);
            //                result.Add(clazz);

            //            }
            //        }
            //    }
            //}
            //return result;
        }

        public void AddNew(ClassModel clazz)
        {
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "INSERT INTO Classes (ClassId) VALUES(@Id)";
            //        cmd.Parameters.AddWithValue("@Id", clazz.Id);
            //        cmd.ExecuteNonQuery();
            //    }
            //}
        }

        public ClassModel GetById(string id)
        {
            throw new NotImplementedException();
            //ClassModel clazz = null;
            //using (var connection = new System.Data.SQLite.SQLiteConnection(this.connectionString))
            //{
            //    connection.Open();
            //    using (var cmd = connection.CreateCommand())
            //    {
            //        cmd.CommandText = "SELECT * FROM Classes WHERE ClassId = @Id";
            //        cmd.Parameters.AddWithValue("@Id", id);
            //        using (var reader = cmd.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                var idd = reader["ClassId"].ToString();
            //                clazz = new ClassModel(idd);
            //            }

            //        }

            //    }

            //}
            //return clazz;
        }
    }
}
