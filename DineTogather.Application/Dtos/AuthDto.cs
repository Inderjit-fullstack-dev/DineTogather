using DineTogather.Domain.Entities;

namespace DineTogather.Application.Dtos
{
    public record AuthDto
    (
        User user,
        string token
    );
}
