using DinnerBooking.Application.Abstraction.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.DinnerMenu.Commands
{
    public sealed record CreateMenuCommand
        (
       string Name,
       string Description,
       List<CreateMenuItemCommand> MenuItems
        ):ICommand;

  

}
