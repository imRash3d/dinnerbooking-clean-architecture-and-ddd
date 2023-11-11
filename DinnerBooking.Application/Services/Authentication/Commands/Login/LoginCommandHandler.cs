using DinnerBooking.Application.Abstraction.Response;
using DinnerBooking.Application.Services.AuthenticationService;
using DinnerBooking.Contracts.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Services.Authentication.Commands.Login;

internal class LoginCommandHandler : ICommandHandler<LoginCommand, CommandResponse>
{
    private readonly IAuthenticationService _authenticationService;

    public LoginCommandHandler(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    public async Task<CommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var response = await _authenticationService.login(request.Email, request.Password);
        return new CommandResponse()
        {
            Results = response
        };

    }
}
