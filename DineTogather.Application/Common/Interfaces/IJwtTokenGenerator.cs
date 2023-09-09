using DineTogather.Domain.Entities;

namespace DineTogather.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(User user);
    }
}
