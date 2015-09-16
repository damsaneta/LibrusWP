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

        public IList<PresenceEntity> GetAllByStudentAndSubject(int studentId, string subjectId)
        {
            return this.context.Presences.Where(x => x.Student.Id == studentId && x.Subject.Id == subjectId).OrderBy(x => x.Id).ToList();
        }
    
        public PresenceEntity GetByStudentAndSubjectAndDate(int studentId, string subjectId, DateTime date)
        {
            return this.context.Presences.Where(x => x.Student.Id == studentId && x.Subject.Id == subjectId && x.Date.Date == date.Date).SingleOrDefault();
        }

        public PresenceEntity GetById(int id)
        {
            return this.context.Presences.Where(x => x.Id == id).SingleOrDefault();
        }

        public void Update(int id, bool presence)
        {
            var entity = this.GetById(id);
            entity.Present = presence;
            this.context.SubmitChanges();
        }
    }
}
