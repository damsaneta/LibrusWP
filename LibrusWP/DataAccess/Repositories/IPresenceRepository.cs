using LibrusWP.DataAccess.Entities;
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
        IList<PresenceEntity> GetAll();

        void AddNew(PresenceEntity model);

        IList<PresenceEntity> GetAllByStudentAndSubject(int studentId, string SubjectId);
        
        PresenceEntity GetByStudentAndSubjectAndDate(int studentId, string subjectId, DateTime date);

        PresenceEntity GetById(int id);

        void Update(int id, bool presence);
    }
}
