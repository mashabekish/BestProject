using Domain.Models;

namespace BusinessLayer.Abstractions;

public interface IItemService
{
    Task<IEnumerable<Item>> GetFoundItemsAsync();
    Task<IEnumerable<Item>> GetFoundItemsAsync(string category);
    Task<IEnumerable<Item>> GetFoundItemsAsync(int userId);
    Task<IEnumerable<Item>> GetLostItemsAsync();
    Task<IEnumerable<Item>> GetLostItemsAsync(string category);
    Task<IEnumerable<Item>> GetLostItemsAsync(int userId);
    Task<Item> CreateFoundItemAsync(Item newFoundItem);
    Task<Item> CreateLostItemAsync(Item newLostItem);
    Task<Item?> EditItemAsync(Item editItem);
    Task<IEnumerable<Item>> GetResolvedItemsAsync();
}
