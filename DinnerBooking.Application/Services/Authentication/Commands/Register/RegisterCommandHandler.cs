using DinnerBooking.Application.Abstraction.Response;
using DinnerBooking.Application.Services.AuthenticationService;
using DinnerBooking.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Services.Authentication.Commands.Login
{
    internal class RegisterCommandHandler : ICommandHandler<RegisterCommand, CommandResponse>
    {
        private readonly IAuthenticationService _authenticationService;

        public RegisterCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<CommandResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var response = await _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            return new CommandResponse()
            {
                Results = response
            };

        }
    }
}
