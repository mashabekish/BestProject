using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public async Task<User> CreateUserAsync(User newUser)
        {
            _db.Users.Add(newUser);
            await _db.SaveChangesAsync();
            return newUser;
        }


        public Task<User?> FindUserByEmailAsync(string email)
        {
            return _db.Users.FirstOrDefaultAsync(u => u.Email.Equals(email));
        }

    }
}
