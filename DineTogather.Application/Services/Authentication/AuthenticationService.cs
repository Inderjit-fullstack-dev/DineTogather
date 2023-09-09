using DineTogather.Application.Common.Interfaces;
using DineTogather.Application.Dtos;
using DineTogather.Application.Exceptions;
using DineTogather.Application.Persistence;
using DineTogather.Application.Requests.Authentication;
using DineTogather.Domain.Entities;

namespace DineTogather.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthDto> Login(LoginRequest request)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not User user)
            {
                throw new NotFoundException("Invalid Email.");
            }

            if (user.Password != request.Password)
            {
                throw new Exception("Invalid password.");
            }

            // generate token

            string token = _jwtTokenGenerator.GenerateJwtToken(user);
            return new AuthDto(user, token);
        } 

        public async Task<AuthDto> Register(RegisterRequest request)
        {
            if (_userRepository.GetUserByEmail(request.Email) is not null)
            {
                throw new NotFoundException("User with given email already exists.");
            }

            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = request.Password
            };

            var userInDb = _userRepository.AddUser(user);

            string token = _jwtTokenGenerator.GenerateJwtToken(userInDb);

            return new AuthDto(user, token);
        }
    }
}
