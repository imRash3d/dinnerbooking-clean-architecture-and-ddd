using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Domain.Entities
{
    public abstract class EntityBase
    {
        public string ItemId { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
    }
}
