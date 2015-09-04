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
        IList<PresenceModel> GetAll();

        void AddNew(PresenceModel model);

        IList<PresenceModel> GetAllByStudentAndSubject(string studentId, string SubjectId);
    }
}
