using DinnerBooking.Application.Services.AuthenticationService;
using DinnerBooking.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DinnerBooking.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        public AuthenticationController(

            IAuthenticationService authenticationService


            )
        {
            _authenticationService = authenticationService;
        }
        [Route("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var response = _authenticationService.Register(request.FirstName, request.LastName, request.Email, request.Password);
            return Ok(response);
        }

        [Route("login")]
        public IActionResult Login(LoginRequest request)
        {
            var response = _authenticationService.login(request.Email, request.Password);
            return Ok(response);
        }
    }
}
