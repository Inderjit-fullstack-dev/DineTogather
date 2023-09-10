using DineTogather.Application.Dtos;
using DineTogather.Application.Requests.Authentication;
using MediatR;

namespace DineTogather.Application.Services.Authentication.Register
{
    public record class RegisterCommand(RegisterRequest registerRequest) : IRequest<AuthDto>;
}
