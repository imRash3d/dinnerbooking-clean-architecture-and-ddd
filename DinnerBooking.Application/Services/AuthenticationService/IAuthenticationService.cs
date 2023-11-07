using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Services.AuthenticationService
{
    public interface IAuthenticationService
    {
        Task<AuthResult> login(string email, string password);
        Task<AuthResult> Register(string firstName, string lastName, string email, string password);
    }
}
