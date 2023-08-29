using DineTogather.Application.Dtos;
using DineTogather.Application.Requests.Authentication;

namespace DineTogather.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AuthDto> Register(RegisterRequest request);
        Task<AuthDto> Login(LoginRequest request);
    }
}
