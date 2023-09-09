using DineTogather.Application.Requests.Authentication;
using DineTogather.Application.Services.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DineTogather.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(RegisterRequest request)
        {
            try
            {
                var response = await _authenticationService.Register(request);
                return Ok(response);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var response = await _authenticationService.Login(request);
            return Ok(response);
        }

    }
}
