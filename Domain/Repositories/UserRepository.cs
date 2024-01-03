using Data;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _db;

        public UserRepository(AppDbContext db)
        {
            _db = db;
        }

        public User CreateUser(User newUser)
        {
            _db.Users.Add(newUser);
            _db.SaveChanges();
            return newUser;
        }

        public User? FindUserByEmail(string email)
        {
            return _db.Users.FirstOrDefault(u => u.Email.Equals(email));
        }
    }
}
