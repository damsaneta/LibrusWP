using LibrusWP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess
{
    public interface ISubjectRepository
    {
        List<Model.SubjectModel> GetAll();

        void AddNew(SubjectModel model);

        Model.SubjectModel GetById(string id);
    }
}
