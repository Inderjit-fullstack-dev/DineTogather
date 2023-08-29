namespace DineTogather.Application.Common.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string GenerateJwtToken(long userId, string firstName, string lastName, string email);
    }
}
