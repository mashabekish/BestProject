using Domain.Models;

namespace Domain.Abstractions;

public interface IItemRepository
{
    Task<IEnumerable<Item>> GetFoundItemsAsync();
    Task<IEnumerable<Item>> GetFoundItemsByCategoryAsync(int categoryId);
    Task<IEnumerable<Item>> GetFoundItemsByUserAsync(int userId);
    Task<IEnumerable<Item>> GetLostItemsAsync();
    Task<IEnumerable<Item>> GetLostItemsByCategoryAsync(int categoryId);
    Task<IEnumerable<Item>> GetLostItemsByUserAsync(int userId);
    Task<Item> CreateItemAsync(Item newItem);
    Task<Item?> EditItemAsync(Item newItem);
    Task<IEnumerable<Item>> GetResolvedItemsAsync();
    Task<Item?> GetItemByIdAsync(int id);
    Task<IEnumerable<Item>> GetMatchingItemsAsync(Item item);
}
