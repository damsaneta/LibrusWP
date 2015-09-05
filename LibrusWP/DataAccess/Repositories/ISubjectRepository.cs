using LibrusWP.DataAccess.Entities;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public interface ISubjectRepository
    {
        List<SubjectEntity> GetAll();

        void AddNew(SubjectEntity model);

        SubjectEntity GetById(string id);
    }
}
