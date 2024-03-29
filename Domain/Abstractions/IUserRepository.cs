﻿using Domain.Models;

namespace Domain.Abstractions
{
    public interface IUserRepository
    {
        public Task<User?> FindUserByEmailAsync(string email);
        public Task<User> CreateUserAsync(User newUser);
        Task<User?> FindUserByIdAsync(int id);
    }
}
