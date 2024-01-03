using Domain.Models;

namespace Domain.Repositories
{
    public interface IUserRepository
    {
        public Task<User?> FindUserByEmailAsync(string email);
        public Task<User> CreateUserAsync(User newUser);
    }
}
