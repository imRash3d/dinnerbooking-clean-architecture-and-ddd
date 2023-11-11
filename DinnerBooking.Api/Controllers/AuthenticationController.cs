using DinnerBooking.Api.Abstraction;
using DinnerBooking.Application.Services.Authentication.Commands.Login;
using DinnerBooking.Contracts.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public sealed class AuthenticationController : ApiController
    {
     
        public AuthenticationController(ISender  sender):base(sender)
        {
           
        }



        [Route("register")]
        public Task<CommandResponse> Register([FromBody] RegisterCommand command)
        {
           return _sender.Send(command);
        }

        [Route("login")]
        public Task<CommandResponse> Login([FromBody] LoginCommand command)
        {
            return _sender.Send(command);
        }
    }
}
