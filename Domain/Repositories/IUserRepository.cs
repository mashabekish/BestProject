using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    internal interface IUserRepository
    {
        public Task<User?> FindUserByEmailAsync(string email);
        public Task<User> CreateUserAsync(User newUser);
    }
}
