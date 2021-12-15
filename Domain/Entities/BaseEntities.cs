using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public long Id { get; set; }

        public DateTime CreationDate { get; set; } = DateTime.Now;

        public DateTime? UpdationDate { get; set; }

        public DateTime? ExclusionDate { get; set; }
    }
}
