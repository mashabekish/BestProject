using Domain.Models;

namespace BusinessLayer.Abstractions;

public interface IItemService
{
    Task<IEnumerable<Item>> GetFoundItemsAsync();
    Task<IEnumerable<Item>> GetFoundItemsByCategoryAsync(int categoryId);
    Task<IEnumerable<Item>> GetFoundItemsByUserAsync(int userId);
    Task<IEnumerable<Item>> GetLostItemsAsync();
    Task<IEnumerable<Item>> GetLostItemsByCategoryAsync(int categoryId);
    Task<IEnumerable<Item>> GetLostItemsByUserAsync(int userId);
    Task<Item> CreateFoundItemAsync(Item newFoundItem);
    Task<Item> CreateLostItemAsync(Item newLostItem);
    Task<Item?> EditItemAsync(Item editItem);
    Task<IEnumerable<Item>> GetResolvedItemsAsync();
    Task<IEnumerable<Item>> GetLostItemsByLocation(Location location);
    Task<IEnumerable<Item>> GetFoundItemsByLocation(Location location);
}
