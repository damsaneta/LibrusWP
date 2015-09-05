using LibrusWP.DataAccess.Entities;
using LibrusWP.DataAccess.Repositories;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LibrusWP.DataAccess
{
    public class ClassRepository : IClassRepository
    {
        private readonly LibrusDataContext context;

        public ClassRepository(LibrusDataContext context)
        {
            this.context = context;
        }

        public List<ClassEntity> GetAll()
        {
            return this.context.Classes.OrderBy(x => x.Id).ToList();
        }

        public void AddNew(ClassEntity entity)
        {
            this.context.Classes.InsertOnSubmit(entity);
            this.context.SubmitChanges();
        }

        public ClassEntity GetById(string id)
        {
            return this.context.Classes.Where(x => x.Id == id).SingleOrDefault();
        }
    }
}
