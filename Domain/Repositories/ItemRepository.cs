﻿using Domain.Abstractions;
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
        return await _db.Items.AsNoTracking()
            .Where(i => i.Flag == Flags.Found && !i.IsResolved)
            .Include(i => i.Image)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetFoundItemsByCategoryAsync(int categoryId)
    {
        return await _db.Items.AsNoTracking()
            .Where(i => i.Flag == Flags.Found && i.CategoryId == categoryId && !i.IsResolved)
            .Include(i => i.Category)
            .Include(i => i.Image)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetFoundItemsByUserAsync(int userId)
    {
        return await _db.Items.AsNoTracking()
            .Where(i => i.Flag == Flags.Found && i.UserId == userId && !i.IsResolved)
            .Include(i => i.User)
            .Include(i => i.Image)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsAsync()
    {
        return await _db.Items.AsNoTracking()
            .Where(i => i.Flag == Flags.Lost && !i.IsResolved)
            .Include(i => i.Image)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsByCategoryAsync(int categoryId)
    {
        return await _db.Items.AsNoTracking()
            .Where(i => i.Flag == Flags.Lost && i.Category.Id == categoryId && !i.IsResolved)
            .Include(i => i.Category)
            .Include(i => i.Image)
            .ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetLostItemsByUserAsync(int userId)
    {
        return await _db.Items.AsNoTracking()
            .Where(i => i.Flag == Flags.Lost && i.UserId == userId && !i.IsResolved)
            .Include(i => i.User)
            .Include(i => i.Image)
            .ToListAsync();
    }

    public async Task<Item> CreateItemAsync(Item newItem)
    {
        _db.Items.Add(newItem);
        await _db.SaveChangesAsync();
        return newItem;
    }

    public async Task<Item?> EditItemAsync(Item editItem)
    {
        var dbItem = await _db.Items
            .FirstOrDefaultAsync(i => i.Id == editItem.Id);

        if (dbItem == null) return null;

        dbItem.Name = editItem.Name;
        dbItem.Description = editItem.Description;
        dbItem.CategoryId = editItem.CategoryId;
        dbItem.Flag = editItem.Flag;
        dbItem.IsResolved = editItem.IsResolved;
        dbItem.Location = editItem.Location;
        dbItem.ImageId = editItem.ImageId;

        await _db.SaveChangesAsync();
        return dbItem;
    }

    public async Task<IEnumerable<Item>> GetResolvedItemsAsync()
    {
        return await _db.Items.AsNoTracking()
            .Where(i => i.IsResolved)
            .Include(i => i.Image)
            .ToListAsync();
    }

    public async Task<Item?> GetItemByIdAsync(int id)
    {
        return await _db.Items
            .Include(i => i.Image)
            .Include(i => i.Notifications)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    public async Task<IEnumerable<Item>> GetMatchingItemsAsync(Item item)
    {
        Flags flag;
        if (item.Flag == Flags.Lost)
            flag = Flags.Found;
        else
            flag = Flags.Lost;
        return await _db.Items
            .Where(i => i.CategoryId == item.CategoryId && !i.IsResolved && i.Flag == flag && item.UserId != i.UserId)
            .Include(i => i.Image)
            .ToListAsync();
    }
}
