using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Services.AuthenticationService
{
    public record AuthResult(

        AuthResponse? Response,
        string? ErroMessage

        );

    public sealed record AuthResponse (
         string Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
