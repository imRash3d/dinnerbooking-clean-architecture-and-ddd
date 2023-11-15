using DinnerBooking.Application.Common.Authentication;
using DinnerBooking.Application.Common.Interfaces.Persistance;
using DinnerBooking.Domain.Entities;
using Serilog;
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
        private readonly ILogger _logger;
        public AuthenticationService(IIdentityService identityService, IUserRepository userRepository, ILogger logger)
        {
            _identityService = identityService;
            _userRepository = userRepository;
            _logger = logger;
        }

        private bool CheckUserPassword(User user, string password)
        {


            if (user != null && password != null && user?.PasswordSalt != null && user.PasswordHash != null)
            {
                using var hmac = new HMACSHA512(user.PasswordSalt);
                var computeHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                for (var i = 0; i < computeHash.Length; i++)
                {
                    if (computeHash[i] != user.PasswordHash[i])
                    {
                        return false;  // Exit early when a mismatch is found
                    }
                }
                return true;
            }
            return false;

        }
        public async Task<AuthResult> login(string email, string password)
        {
            try
            {

                var user = await _userRepository.GetUserByEmail(email);
                if (user is null)
                {
                    return new AuthResult(null, "Email not exist");
                }

                if (CheckUserPassword(user, password) is false)
                {
                    return new AuthResult(null, "Email and Password dont match ");
                }
                string token = _identityService.GenerateToken(user.ItemId, user.Email, user.FirstName, user.LastName);


                var response = new AuthResult(
                    new AuthResponse(
                         user.ItemId,
                 user.FirstName,
                 user.LastName,
                 user.Email,
                 token),
                    null
                  );
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                _logger.Error(" Failed to login by email {@email} {@message}", email, ex.Message);

            }
            return new AuthResult(null, "$Failed to lohin by email {email}");
        }

        public async Task<AuthResult> Register(string firstName, string lastName, string email, string password)
        {

            try
            {

                // check email exist 

                var userExist = await _userRepository.GetUserByEmail(email);
                if (userExist is not null)
                {
                    return new AuthResult(null, "Email already exist  ");
                }

                UserFactory userFactory = new UserFactory();
                var user = userFactory.CreateUser(firstName, lastName, email, password);

                await _userRepository.SaveUser(user);

                // create token 
                string token = _identityService.GenerateToken(user.ItemId, user.Email, user.FirstName, user.LastName);


                var response = new AuthResult(
                 new AuthResponse(
                       user.ItemId,
                 user.FirstName,
                 user.LastName,
                 user.Email,
                 token),
                 null
               );
                return await Task.FromResult(response);
            }
            catch (Exception ex)
            {
                _logger.Error(" Failed to register by email {@email} {@message}", email, ex.Message);
               
            }

            return new AuthResult(null, "Failed to register ");
        }
    }
}
