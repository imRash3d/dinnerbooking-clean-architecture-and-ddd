using DinnerBooking.Api.Abstraction;
using DinnerBooking.Application.DinnerMenu.Commands;
using DinnerBooking.Application.Services.Authentication.Commands.Login;
using DinnerBooking.Contracts.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers
{
    [ApiController]
    [Route("menu")]
    public sealed class MenuController : ApiController
    {
     
        public MenuController(ISender  sender):base(sender)
        {
           
        }



        [Route("Create")]
        [HttpPost]
        public Task<CommandResponse> CreateMenu([FromBody] CreateMenuCommand command)
        {
           return _sender.Send(command);
        }

    
    }
}
