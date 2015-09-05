using LibrusWP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Repositories
{
    public class LibrusDataContext : DataContext
    {
        public LibrusDataContext(string connectionString)
            : base(connectionString)
        {
        }

        public Table<ClassEntity> Classes;
        public Table<StudentEntity> Students;
        public Table<SubjectEntity> Subjects;
        public Table<TimeTableEntity> TimeTables;
        public Table<PresenceEntity> Presences;

    }
}
