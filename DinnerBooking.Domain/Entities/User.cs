using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Domain.Entities
{
    public class User:EntityBase
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public User()
        {
            ItemId = Guid.NewGuid().ToString();
            CreateDate = DateTime.UtcNow;
            LastUpdateDate = DateTime.UtcNow;
            
        }
    }
}
