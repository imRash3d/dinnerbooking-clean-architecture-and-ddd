using DinnerBooking.Application.Common.Authentication;
using DinnerBooking.Application.Common.Interfaces.Persistance;
using DinnerBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Services.AuthenticationService
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IIdentityService _identityService;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IIdentityService identityService, IUserRepository userRepository)
        {
            _identityService = identityService;
            _userRepository = userRepository;
        }

        private bool CheckUserPassword(User user, string password)
        {
            bool isValid = true;
            using var hmac = new HMACSHA512(user.PasswordSalt);
            var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (var i = 0; i < computeHash.Length; i++)
            {
                if (computeHash[i] != user.PasswordHash[i])
                {
                    isValid = true;
                }
            }
            return isValid;
        }
        public async Task<AuthResult> login(string email, string password)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);
                if (user is null)
                {
                    throw new NotImplementedException("Email not exist ");
                }
               
                if(CheckUserPassword(user, password) is false)
                {
                    throw new NotImplementedException("Password not match  ");
                }
                string token = await _identityService.GenerateToken(user.ItemId, user.FirstName, user.LastName);
                var response = new AuthResult(
                 user.ItemId,
                 user.FirstName,
                 user.LastName,
                 user.Email,
                 token
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

                // check email exist 
                var userExist = await _userRepository.GetUserByEmail(email);
                if (userExist is not null)
                {
                    throw new NotImplementedException("Email already exist ");
                }

                using var hmac = new HMACSHA512();
                var user = new User()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password)),
                    PasswordSalt = hmac.Key
                };

                await _userRepository.CreateUser(user);

                // create token 
                string token = await _identityService.GenerateToken(user.ItemId, user.FirstName, user.LastName);

                var response = new AuthResult(

                 user.ItemId,
                 user.FirstName,
                 user.LastName,
                 user.Email,
                 token
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
