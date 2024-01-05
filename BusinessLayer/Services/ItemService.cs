using BusinessLayer.Abstractions;
using BusinessLayer.Utils;
using Domain.Abstractions;
using Domain.Models;

namespace BusinessLayer.Services;

public class ItemService : IItemService
{
    private readonly IItemRepository _itemRepository;

    public ItemService(IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
    }

    public async Task<IEnumerable<Item>> GetFoundItemsAsync()
    {
        return await _itemRepository.GetFoundItemsAsync();
    }

    public async Task<IEnumerable<Item>> GetFoundItemsByCategoryAsync(int categoryId)
    {
        return await _itemRepository.GetFoundItemsByCategoryAsync(categoryId);
    }

    public async Task<IEnumerable<Item>> GetFoundItemsByUserAsync(int userId)
    {
        return await _itemRepository.GetFoundItemsByUserAsync(userId);
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync()
    {
        return await _itemRepository.GetLostItemsAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsByCategoryAsync(int categoryId)
    {
        return await _itemRepository.GetLostItemsByCategoryAsync(categoryId);
    }

    public async Task<IEnumerable<Item>> GetLostItemsByUserAsync(int userId)
    {
        return await _itemRepository.GetLostItemsByUserAsync(userId);
    }

    public async Task<Item> CreateFoundItemAsync(Item newFoundItem)
    {
        newFoundItem.Flag = Flags.Found;
        return await _itemRepository.CreateItemAsync(newFoundItem);
    }

    public async Task<Item> CreateLostItemAsync(Item newLostItem)
    {
        newLostItem.Flag = Flags.Lost;
        return await _itemRepository.CreateItemAsync(newLostItem);
    }

    public async Task<Item?> EditItemAsync(Item editItem)
    {
        return await _itemRepository.EditItemAsync(editItem);
    }

    public async Task<IEnumerable<Item>> GetResolvedItemsAsync()
    {
        return await _itemRepository.GetResolvedItemsAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsByLocation(Location location)
    {
        var allLostItems = await _itemRepository.GetLostItemsAsync();
        return allLostItems.Where(item => ItemLocationHelpers.LocationIntersects(location, item.Location)).ToList();
    }
    public async Task<IEnumerable<Item>> GetFoundItemsByLocation(Location location)
    {
        var allLostItems = await _itemRepository.GetFoundItemsAsync();
        return allLostItems.Where(item => ItemLocationHelpers.LocationIntersects(location, item.Location)).ToList();
    }

    public async Task<Item?> GetItemById(int id)
    {
        return await _itemRepository.GetItemByIdAsync(id);
    }

    public async Task<IEnumerable<Notification>?> GetNotificationsByItemId(int id)
    {
        var item =  await _itemRepository.GetItemByIdAsync(id);
        if (item == null)
            throw new ArgumentNullException();
        return item.Notifications;
    }

    public async Task<IEnumerable<Item>> GetMatchingItems(Item item)
    {
        var matchingItems = await _itemRepository.GetMatchingItemsAsync(item);
        return matchingItems
            .Where(i => ItemLocationHelpers.LocationIntersects(item.Location, i.Location))
            .ToList();

    }
}
