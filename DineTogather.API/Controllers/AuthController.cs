using DineTogather.Application.Requests.Authentication;
using DineTogather.Application.Services.Authentication.Login;
using DineTogather.Application.Services.Authentication.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DineTogather.API.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(RegisterRequest request)
        {
            try
            {
                var response = await _mediator.Send(new RegisterCommand(request));
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
            var response = await _mediator.Send(new LoginQuery(request));
            return Ok(response);
        }
    }
}
