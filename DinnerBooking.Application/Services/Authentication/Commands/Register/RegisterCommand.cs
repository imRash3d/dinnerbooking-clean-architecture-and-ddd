using DinnerBooking.Application.Abstraction.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Application.Services.Authentication.Commands.Login
{
    public sealed record RegisterCommand
  (
    string FirstName,
    string LastName,
    string Email,
    string Password
  ) :ICommand;
}
