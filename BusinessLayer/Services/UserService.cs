using BusinessLayer.Abstractions;
using Domain.Models;
using Domain.Repositories;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User CreateUser(User newUser)
        {
            return _userRepository.CreateUser(newUser);
        }

        public User? FindUserByEmail(string email)
        {
            return _userRepository.FindUserByEmail(email);
        }
    }
}
