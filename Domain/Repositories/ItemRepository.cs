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
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetFoundItemsAsync(string category)
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Found && i.Category.Name == category && !i.IsResolved)
            .Include(i => i.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetFoundItemsAsync(int userId)
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Found && i.UserId == userId && !i.IsResolved)
            .Include(i => i.User)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync()
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Lost && !i.IsResolved)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync(string category)
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Lost && i.Category.Name == category && !i.IsResolved)
            .Include(i => i.Category)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync(int userId)
    {
        return await _db.Items
            .Where(i => i.Flag == Flags.Lost && i.UserId == userId && !i.IsResolved)
            .Include(i => i.User)
            .ToListAsync();
    }

    public async Task<Item> CreateItemAsync(Item newItem)
    {
        _db.Items.Add(newItem);
        await _db.SaveChangesAsync();
        return newItem;
    }

    public async Task<IEnumerable<Item>> GetResolvedItemsAsync()
    {
        return await _db.Items.Where(i => i.IsResolved).ToListAsync();
    }
}
