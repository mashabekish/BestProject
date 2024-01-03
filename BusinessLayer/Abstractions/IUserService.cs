using Domain.Models;

namespace BusinessLayer.Abstractions
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User newUser);

        Task<User?> FindUserByEmailAsync(string email);
    }
}
