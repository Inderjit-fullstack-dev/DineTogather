namespace DineTogather.Contracts.Authentication
{
    public record AuthResponse
    (
        long UserId,
        string FirstName,
        string LastName,
        string Email,
        string Token
    );
}
