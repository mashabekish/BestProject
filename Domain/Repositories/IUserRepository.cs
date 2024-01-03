using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public User? FindUserByEmail(string email);
        public User CreateUser(User newUser);
    }
}
