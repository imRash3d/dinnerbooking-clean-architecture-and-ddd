using DinnerBooking.Application.Abstraction.Response;
using DinnerBooking.Application.Services.DinnerMenu;
using DinnerBooking.Contracts.Common;
using DinnerBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.DinnerMenu.Commands
{
    internal sealed class CreateMenuCommandhandler : ICommandHandler<CreateMenuCommand, CommandResponse>
    {
        private readonly IMenuRepository _menuRepository;

        public CreateMenuCommandhandler(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }


  

        public async Task<CommandResponse> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            var menu = new Menu(request.Name, request.Description);

            if (request.MenuItems.Any())
            {
                foreach (var item in request.MenuItems)
                {
                    var menuItem = new MenuItem(item.Name, item.Description, item.Price);
                    menu.AddMenuItem(menuItem);
                }
            }
            var response = await _menuRepository.CreateMenu(menu);
            return new CommandResponse()
            {
                Results = response
            };
        }
    }
}
