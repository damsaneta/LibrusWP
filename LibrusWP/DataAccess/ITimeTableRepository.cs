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
        IList<TimeTableModel> GetAll();

        IList<TimeTableModel> GetAllByClass(string clazzId);

        void AddNew(TimeTableModel model);

        TimeTableModel GetByClassAndSubject(string classId, string subjectId);

        TimeTableModel GetById(int timetableId);
    }
}
