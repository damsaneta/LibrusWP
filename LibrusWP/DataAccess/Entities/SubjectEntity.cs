using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name = "Subjects")]
    public class SubjectEntity
    {
        public SubjectEntity()
        {

        }
        public SubjectEntity(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        [Column(Name = "Id", IsPrimaryKey = true, CanBeNull = false )]
        public string Id { get; private set; }

        [Column(Name = "Name", CanBeNull = false)]
        public string Name { get; private set; }
    }
}
