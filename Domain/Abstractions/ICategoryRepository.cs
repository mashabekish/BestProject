using Domain.Models;

namespace Domain.Abstractions;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
}
