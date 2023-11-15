using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Domain.Abstraction;

public abstract class EntityBase
{
    public string ItemId { get; set; }
    public virtual DateTime CreateDate { get; set; }
    public virtual DateTime LastUpdateDate { get; set; }
    protected EntityBase()
    {
        ItemId = Guid.NewGuid().ToString(); 
        CreateDate = DateTime.UtcNow;
        LastUpdateDate = DateTime.UtcNow;
    }

}
