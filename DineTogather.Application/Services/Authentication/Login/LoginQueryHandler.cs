using DineTogather.Application.Common.Interfaces;
using DineTogather.Application.Dtos;
using DineTogather.Application.Exceptions;
using DineTogather.Application.Persistence;
using DineTogather.Domain.Entities;
using MediatR;

namespace DineTogather.Application.Services.Authentication.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthDto>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;
        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthDto> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.loginRequest.Email) is not User user)
            {
                throw new NotFoundException("Invalid Email.");
            }

            if (user.Password != request.loginRequest.Password)
            {
                throw new Exception("Invalid password.");
            }

            // generate token

            string token = _jwtTokenGenerator.GenerateJwtToken(user);
            return new AuthDto(user, token);
        }
    }
}
