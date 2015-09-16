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
    public class TimeTableRepository : ITimeTableRepository
    {

        private readonly LibrusDataContext context;

        public TimeTableRepository(LibrusDataContext context)
        {
            this.context = context;
        }

        public IList<TimeTableEntity> GetAll()
        {
            return this.context.TimeTables.ToList();
        }

        public IList<TimeTableEntity> GetAllByClass(string clazzId)
        {
            return this.context.TimeTables.Where(x => x.Class.Id == clazzId).ToList();
        }

        public void AddNew(TimeTableEntity model)
        {
            this.context.TimeTables.InsertOnSubmit(model);
            this.context.SubmitChanges();
        }

        public TimeTableEntity GetByClassAndSubject(string classId, string subjectId)
        {
            return this.context.TimeTables.Where(x => x.Class.Id == classId && x.Subject.Id == subjectId).SingleOrDefault();

        }

        public TimeTableEntity GetById(int timetableId)
        {
            return this.context.TimeTables.Where(x => x.Id == timetableId).SingleOrDefault();

        }
    }
}
