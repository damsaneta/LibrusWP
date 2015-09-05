using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrusWP.DataAccess.Entities
{
    [Table(Name = "Classes")]
    public class ClassEntity
    {
        public ClassEntity()
        {
        }

        public ClassEntity(string classId)
        {
            this.Id = classId;
        }

        [Column(Name = "Id", CanBeNull = false, IsPrimaryKey = true)]
        public string Id { get; private set; }
    }
}
