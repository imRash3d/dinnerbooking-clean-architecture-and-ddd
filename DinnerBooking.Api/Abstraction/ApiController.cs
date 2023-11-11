using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Abstraction;

public abstract class ApiController : ControllerBase
{
    protected readonly ISender  _sender;
    protected ApiController(ISender sender)
    {
        _sender = sender;
    }   
}
