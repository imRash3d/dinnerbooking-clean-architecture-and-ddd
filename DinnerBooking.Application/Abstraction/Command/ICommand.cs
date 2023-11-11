using DinnerBooking.Contracts.Common;
using MediatR;


namespace DinnerBooking.Application.Abstraction.Response
{
    public interface ICommand : IRequest<CommandResponse>
    {
    }
   
}
