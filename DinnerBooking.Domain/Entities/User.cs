using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DinnerBooking.Domain.Abstraction;

namespace DinnerBooking.Domain.Entities;

public class User:EntityBase
{
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string Email { get; set; }
    public byte[] PasswordHash { get; private set; }
    public byte[] PasswordSalt { get; private set; }

   
    internal void SetPassword(byte[] passwordHash, byte[] passwordSalt)
    {
        PasswordHash = passwordHash;
        PasswordSalt = passwordSalt;
    }
}

public class UserFactory
{
    public User CreateUser(string firstName, string lastName, string email, string password)
    {
        using var hmac = new HMACSHA512();
        byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
        byte[] passwordSalt = hmac.Key;

        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
       

        };
        user.SetPassword(passwordHash, passwordSalt);
        return user;
    }
}

