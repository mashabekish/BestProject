using Domain.Models;

namespace Domain.Abstractions;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetFoundItemsAsync();
    Task<IEnumerable<Item>> GetFoundItemsAsync(string category);
    Task<IEnumerable<Item>> GetFoundItemsAsync(int userId);
    Task<IEnumerable<Item>> GetLostItemsAsync();
    Task<IEnumerable<Item>> GetLostItemsAsync(string category);
    Task<IEnumerable<Item>> GetLostItemsAsync(int userId);
    Task<Item> CreateItemAsync(Item newItem);
    Task<IEnumerable<Item>> GetResolvedItemsAsync();
}
