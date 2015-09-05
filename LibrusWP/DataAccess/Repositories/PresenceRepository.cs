using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public class PresenceRepository: IPresenceRepository
    {

        private readonly LibrusDataContext context;

        public PresenceRepository(LibrusDataContext context)
        {
            this.context = context;
        }

        public IList<PresenceEntity> GetAll()
        {
           return this.context.Presences.OrderBy(x => x.Id).ToList();
        }


        public void AddNew(PresenceEntity model)
        {
            this.context.Presences.InsertOnSubmit(model);
            this.context.SubmitChanges();
        }

        public IList<PresenceEntity> GetAllByStudentAndSubject(string studentId, string subjectId)
        {
            //return this.context.Presences.Where(x => x.StudentId == studentId && x.SubjectId == subjectId).ToList();
            throw new NotImplementedException();
        }
    }
}
