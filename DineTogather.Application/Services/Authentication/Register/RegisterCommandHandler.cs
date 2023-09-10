using DineTogather.Application.Common.Interfaces;
using DineTogather.Application.Dtos;
using DineTogather.Application.Exceptions;
using DineTogather.Application.Persistence;
using DineTogather.Domain.Entities;
using MediatR;

namespace DineTogather.Application.Services.Authentication.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthDto>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public async Task<AuthDto> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            if (_userRepository.GetUserByEmail(request.registerRequest.Email) is not null)
            {
                throw new NotFoundException("User with given email already exists.");
            }

            var user = new User
            {
                FirstName = request.registerRequest.FirstName,
                LastName = request.registerRequest.LastName,
                Email = request.registerRequest.Email,
                Password = request.registerRequest.Password
            };

            var userInDb = _userRepository.AddUser(user);

            string token = _jwtTokenGenerator.GenerateJwtToken(userInDb);

            return new AuthDto(user, token);
        }
    }
}
