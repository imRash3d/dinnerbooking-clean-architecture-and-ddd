using DinnerBooking.Application.Abstraction.Response;
using DinnerBooking.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.DinnerMenu.Commands
{
    internal sealed class CreateMenuItemCommandhandler : ICommandHandler<CreateMenuCommand, CommandResponse>
    {

     

        public Task<CommandResponse> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
