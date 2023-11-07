using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        public async Task<AuthResult> login(string email, string password)
        {
            try
            {
                var response = new AuthResult(

                 Guid.NewGuid(),
                 "FirstName",
                 "LastName",
                 email,
                 "Token"
                  );
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();

            }
        }

        public async Task<AuthResult> Register(string firstName, string lastName, string email, string password)
        {

            try
            {
                var response = new AuthResult(

                 Guid.NewGuid(),
                 "FirstName",
                 "LastName",
                 email,
                 "Token"
                  );
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
        }
    }
}
