using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Common.Authentication
{
    public interface IIdentityService
    {
        Task<string> GenerateToken(string userId, string firstName, string lastName);
    }
}
