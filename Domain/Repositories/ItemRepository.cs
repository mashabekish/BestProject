using Domain.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class ItemRepository : IItemRepository
{
    private readonly AppDbContext _db;

    public ItemRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Item>> GetFoundItemsAsync()
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Found && !i.IsResolved)
            .Include(i => i.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetFoundItemsAsync(string category)
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Found && i.Category.Name == category && !i.IsResolved)
            .Include(i => i.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync()
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Lost && !i.IsResolved)
            .Include(i => i.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync(string category)
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Lost && i.Category.Name == category && !i.IsResolved)
            .Include(i => i.Category)
            .ToListAsync();
    }

    private async Task<Item> CreateItemAsync(Item newItem)
    {
        _db.Items.Add(newItem);
        await _db.SaveChangesAsync();
        return newItem;
    }

    public async Task<Item> CreateFoundItemAsync(Item newFoundItem)
    {
        ///TODO: validation
        return await CreateItemAsync(newFoundItem);
    }

    public async Task<Item> CreateLostItemAsync(Item newLostItem)
    {
        ///TODO: validation
        return await CreateItemAsync(newLostItem);
    }

    public async Task<IEnumerable<Item>> GetResolvedItemsAsync()
    {
        return await _db.Items.Where(i => i.IsResolved).ToListAsync();
    }
}
