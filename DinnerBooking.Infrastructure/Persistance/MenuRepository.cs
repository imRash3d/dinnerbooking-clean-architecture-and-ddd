
using DinnerBooking.Application.Services.DinnerMenu;
using DinnerBooking.Domain.Entities;
using DinnerBooking.Infrastructure.Abstraction;
using Serilog;

namespace DinnerBooking.Infrastructure.Persistance
{
    internal sealed class MenuRepository : IMenuRepository
    {
        private readonly IRepository _repository;
        private readonly ILogger _logger;
        public MenuRepository(IRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public async Task<Menu?> CreateMenu(Menu menu)
        {


            try
            {
                _logger.Information("call create menu service {@Menu}", menu);
                await _repository.SaveAsync(menu);
                
            }
            catch (Exception ex)
            {
                _logger.Error(" Failed to  create menu service {@Menu} {@message}", menu,ex.Message);
            }
            return null;

        }

        public async Task CreateMenuItem(string menuId, string name, string description, float price)
        {
            try
            {
                var menu = await GetMenuById(menuId);
                if(menu is not null)
                {
                    var menuItem = new MenuItem(name, description, price);
                    menu.AddMenuItem(menuItem);
                   await _repository.SaveAsync(menu);
                }
            }
            catch (Exception ex)
            {
                _logger.Error(" Failed to  create menu Item  {@Menu} {@message}", menuId, ex.Message);
            }
           
           
        }

        public async Task DeleteMenu(string menuId)
        {
           try
            {
                await _repository.DeleteAsync<Menu>(x => x.ItemId == menuId);
            }
            catch(Exception ex)
            {
                _logger.Error(" Failed to  delete menu {@Menu} {@message}", menuId, ex.Message);
            }
        }

        public async Task<List<Menu>> GetAllMenu()
        {
            try
            {
                return (List<Menu>)await _repository.GetItemsAsync<Menu>();
            }
            catch (Exception ex)
            {
                _logger.Error(" Failed to  fetch all  menu {@message}", ex.Message);
            }
            return new List<Menu>();


        }

        public async Task<Menu?> GetMenuById(string menuId)
        {
            try
            {
                return await _repository.GetItemAsync<Menu>(x => x.ItemId == menuId);
            }
            catch (Exception ex)
            {
                _logger.Error(" Failed to fetch menu by Id {@message}", ex.Message);
            }
            return null;

        }
    }
}
