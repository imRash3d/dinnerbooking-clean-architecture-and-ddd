using DinnerBooking.Contracts.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Abstraction.Response
{
    public interface ICommandHandler<TCommand,TResponse>:IRequestHandler<TCommand, CommandResponse>
        where TCommand : ICommand
    {
    }
}
