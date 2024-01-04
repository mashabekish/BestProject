using BusinessLayer.Abstractions;
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

    public async Task<IEnumerable<Item>> GetFoundItemsAsync(string category)
    {
        return await _itemRepository.GetFoundItemsAsync(category);
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync()
    {
        return await _itemRepository.GetLostItemsAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync(string category)
    {
        return await _itemRepository.GetLostItemsAsync(category);
    }

    public async Task<Item> CreateFoundItemAsync(Item newFoundItem)
    {
        return await _itemRepository.CreateFoundItemAsync(newFoundItem);
    }

    public async Task<Item> CreateLostItemAsync(Item newLostItem)
    {
        return await _itemRepository.CreateLostItemAsync(newLostItem);
    }

    public async Task<IEnumerable<Item>> GetResolvedItemsAsync()
    {
        return await _itemRepository.GetResolvedItemsAsync();
    }
}
