namespace DineTogather.Application.Dtos
{
    public record AuthDto
    (
        long UserId,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
