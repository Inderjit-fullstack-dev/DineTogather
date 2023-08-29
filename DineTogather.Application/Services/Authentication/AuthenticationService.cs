using DineTogather.Application.Common.Interfaces;
using DineTogather.Application.Dtos;
using DineTogather.Application.Requests.Authentication;

namespace DineTogather.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<AuthDto> Login(LoginRequest request)
        {
            // check if user credentials maches with row in a table

            // generate token

            string token = _jwtTokenGenerator.GenerateJwtToken(1, "inderjit", "singh", request.Email);

            return new AuthDto(1, "inderjit", "singh", request.Email, token);
        } 

        public async Task<AuthDto> Register(RegisterRequest request)
        {
            return new AuthDto(1, request.FirstName, request.LastName, request.Email, "token");
        }
    }
}
