using Domain.Abstractions;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _db;

    public CategoryRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _db.Categories.AsNoTracking().ToListAsync();
    }
}
