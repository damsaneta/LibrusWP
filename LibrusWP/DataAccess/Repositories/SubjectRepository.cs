using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public class SubjectRepository: ISubjectRepository
    {
        private readonly LibrusDataContext context;

        public SubjectRepository(LibrusDataContext context)
        {
            this.context= context;
        }

        public List<SubjectEntity> GetAll()
        {
            return this.context.Subjects.OrderBy(x => x.Name).ToList();
        }

        public void AddNew(SubjectEntity model)
        {
            this.context.Subjects.InsertOnSubmit(model);
            this.context.SubmitChanges();
        }

        public SubjectEntity GetById(string id)
        {
            return this.context.Subjects.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
