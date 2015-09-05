using LibrusWP.DataAccess.Entities;
using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public interface ITimeTableRepository
    {
        IList<TimeTableEntity> GetAll();

        IList<TimeTableEntity> GetAllByClass(string clazzId);

        void AddNew(TimeTableEntity model);

        TimeTableEntity GetByClassAndSubject(string classId, string subjectId);

        TimeTableEntity GetById(int timetableId);
    }
}
