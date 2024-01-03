using Domain.Models;

namespace BusinessLayer.Abstractions
{
    public interface IUserService
    {
        User CreateUser(User newUser);

        User? FindUserByEmail(string email);
    }
}
