using DineTogather.Application.Persistence;
using DineTogather.Domain.Entities;
namespace DineTogather.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {
        private List<User> _users = new()
        {
            new User
            {
                Id = 1,
                FirstName = "Inderjit",
                LastName = "Singh",
                Email = "inderjit@gmail.com",
                Password = "password"
            }
        };

        public User AddUser(User user)
        {
            user.Id = _users.Last().Id + 1;
            _users.Add(user);
            return user;
        }

        public User? GetUserByEmail(string email) => _users.FirstOrDefault(u => u.Email == email);

    }
}
