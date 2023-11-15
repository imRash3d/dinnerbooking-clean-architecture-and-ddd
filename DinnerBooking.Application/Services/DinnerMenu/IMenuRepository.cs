
using DinnerBooking.Domain.Entities;


namespace DinnerBooking.Application.Services.DinnerMenu
{
    public interface IMenuRepository
    {
        Task<Menu?> CreateMenu(Menu menu);
        Task DeleteMenu(string menuId);
        Task<Menu?> GetMenuById(string menuId);
        Task<List<Menu>> GetAllMenu();
        Task CreateMenuItem(string menuId, string name, string description, float price);
    }
}
