using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Infrastructure.Authentication
{
    public static class IdentityHelper
    {

        public static byte[] GeneratekeyBytes(string key)
            {
                    using var hmac = new HMACSHA256();
                    byte[] keyBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(key));
                    return keyBytes;
            }
    }
}
