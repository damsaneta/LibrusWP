using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public class PresenceRepository: IPresenceRepository
    {
        private readonly string connectionString;

        public PresenceRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Model.PresenceModel> GetAll()
        {
            throw new NotImplementedException();
        }


        public void AddNew(Model.PresenceModel model)
        {
            throw new NotImplementedException();
        }

        public IList<Model.PresenceModel> GetAllByStudentAndSubject(string studentId, string SubjectId)
        {
            throw new NotImplementedException();
        }
    }
}
