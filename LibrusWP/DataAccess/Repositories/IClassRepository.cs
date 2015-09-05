using LibrusWP.DataAccess.Entities;
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
        List<ClassEntity> GetAll();
        void AddNew(ClassEntity clazz);
        ClassEntity GetById(string id);
    }
}
