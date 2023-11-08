using DinnerBooking.Application.Common.Interfaces.Persistance;
using DinnerBooking.Domain.Entities;
using DinnerBooking.Infrastructure.Adapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Infrastructure.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository _repository;
        public UserRepository(IRepository repository)
        {
            _repository = repository;
        }
        public async Task CreateUser(User user)
        {
            await _repository.SaveAsync(user);
           
        }

        public async Task DeleteUser(string userId)
        {
            await _repository.DeleteAsync<User>(x=>x.ItemId ==userId);
        }

        public async Task<User> GetUserByEmail(string email)
        {
           return (User)await _repository.GetItemsAsync<User>(x => x.Email == email);
        }

        public async Task<User> GetUserById(string userId)
        {
            return (User)await _repository.GetItemsAsync<User>(x => x.ItemId == userId);
        }

        public async Task UpdateUser(User user)
        {
             await _repository.SaveAsync<User>(user);
        }
    }
}
