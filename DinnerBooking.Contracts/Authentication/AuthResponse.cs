using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerBooking.Contracts.Authentication;

public record AuthResponse(

    string ItemId,
    string FirstName,
    string LastName,
    string Email,
    string Token

  );


