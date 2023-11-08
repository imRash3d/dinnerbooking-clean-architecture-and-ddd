using DinnerBooking.Application.Common.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Infrastructure.Authentication
{
    public class IdentityService : IIdentityService
    {

        public Task<string> GenerateToken(string userId, string firstName, string lastName)
        {
            try
            {
                var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, userId),
                        new Claim(JwtRegisteredClaimNames.FamilyName, firstName),
                        new Claim(JwtRegisteredClaimNames.GivenName, lastName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    };

                var credentials = new SigningCredentials(
                    new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("secret-key")
                    ),
                    SecurityAlgorithms.HmacSha512Signature
                );

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(7),
                    SigningCredentials = credentials
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return Task.FromResult(tokenHandler.WriteToken(token));
            }
            catch (Exception ex)
            {
                // Handle the exception, log it, and return an error message or null
                // For example:
                // LogException(ex);
                // return Task.FromResult<string>(null); // or return Task.FromResult("Error message");
                // Make sure to handle the exception as appropriate for your application.
            }
            return Task.FromResult(string.Empty);

        }

    }
}
