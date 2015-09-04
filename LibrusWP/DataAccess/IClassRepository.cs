using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public interface IClassRepository
    {
        List<ClassModel> GetAll();
        void AddNew(ClassModel clazz);
        ClassModel GetById(string id);
    }
}
