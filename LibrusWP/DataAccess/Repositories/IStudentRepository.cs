using LibrusWP.DataAccess.Entities;
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
        IList<StudentEntity> GetAll();

        IList<StudentEntity> GetAllByClass(string classId);

        void AddNew(StudentEntity model);

        StudentEntity GetById(int id);
    }
}
