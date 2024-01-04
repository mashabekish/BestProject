using BusinessLayer.Abstractions;
using Domain.Abstractions;
using Domain.Models;

namespace BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            return await _userRepository.CreateUserAsync(newUser);
        }

        public async Task<User?> FindUserByEmailAsync(string email)
        {
            return await _userRepository.FindUserByEmailAsync(email);
        }
    }
}
