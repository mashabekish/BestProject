﻿using Domain.Models;

namespace Domain.Abstractions;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetFoundItemsAsync();
    Task<IEnumerable<Item>> GetFoundItemsAsync(string category);
    Task<IEnumerable<Item>> GetLostItemsAsync();
    Task<IEnumerable<Item>> GetLostItemsAsync(string category);
    Task<Item> CreateFoundItemAsync(Item newFoundItem);
    Task<Item> CreateLostItemAsync(Item newLostItem);
    Task<IEnumerable<Item>> GetResolvedItemsAsync();
}