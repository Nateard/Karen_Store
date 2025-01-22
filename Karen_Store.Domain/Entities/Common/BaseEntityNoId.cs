using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karen_Store.Domain.Entities.Common
{

    public abstract class BaseEntityNoId
    {
        public long InsertByUserId { get; set; }
        public DateTime InsertDateTime { get; set; } = DateTime.Now;
        public long? UpdateByUserId { get; set; }
        public DateTime? UpdateDateTime { get; set; }
        public long? DeleteByUserId { get; set; }
        public DateTime? DeleteDateTime { get; set; }
        public bool IsDeleted { get; set; }
    }

}
