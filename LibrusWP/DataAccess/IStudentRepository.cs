using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public interface IStudentRepository
    {
        IList<StudentModel> GetAll();

        IList<StudentModel> GetAllByClass(string classId);

        void AddNew(StudentModel model);

        StudentModel GetById(int id);
    }
}
