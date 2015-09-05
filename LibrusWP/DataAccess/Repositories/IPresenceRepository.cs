using LibrusWP.DataAccess.Entities;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public interface IPresenceRepository
    {
        IList<PresenceEntity> GetAll();

        void AddNew(PresenceEntity model);

        IList<PresenceEntity> GetAllByStudentAndSubject(string studentId, string SubjectId);
    }
}
