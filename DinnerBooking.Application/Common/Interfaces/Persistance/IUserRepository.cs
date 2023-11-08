
using DinnerBooking.Domain.Entities;

namespace DinnerBooking.Application.Common.Interfaces.Persistance
{
    public interface IUserRepository
    {
        Task<User> GetUserById(string userId);
        Task<User> GetUserByEmail(string email);
        Task CreateUser(User user);
        Task UpdateUser(User user);
        Task DeleteUser(string userId);
    }
}
