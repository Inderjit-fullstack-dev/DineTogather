using DineTogather.Application.Dtos;
using DineTogather.Application.Requests.Authentication;
using MediatR;

namespace DineTogather.Application.Services.Authentication.Login
{
    public record LoginQuery(LoginRequest loginRequest) : IRequest<AuthDto>;
}
