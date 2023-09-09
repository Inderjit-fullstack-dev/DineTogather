using DineTogather.Domain.Entities;

namespace DineTogather.Application.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        User AddUser(User user);
    }
}
