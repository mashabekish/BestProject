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
        public User? FindUserByEmail(string email);
        public User CreateUser(User newUser);
    }
}
