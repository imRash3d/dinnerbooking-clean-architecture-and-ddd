using DinnerBooking.Application.Common.Authentication;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Infrastructure.Authentication
{
    internal sealed class IdentityService : IIdentityService
    {


        public string GenerateToken(string userId, string email, string firstName, string lastName)
        {
            try
            {
                var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim("display_name", $"{firstName} {lastName}"),
                        new Claim("user_id", userId),
                        new Claim("email", email),
                    };

                var key = new SymmetricSecurityKey(IdentityHelper.GeneratekeyBytes("secret-key"));
                var credentials = new SigningCredentials(
                    key,
                    SecurityAlgorithms.HmacSha256
                );

                var tokenDescriptor = new JwtSecurityToken
               (
                    issuer:"DXBooking",
                    claims : claims,
                    expires : DateTime.Now.AddDays(7),
                    signingCredentials : credentials

                );

                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(tokenDescriptor);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            return string.Empty;

        }

    }
}
