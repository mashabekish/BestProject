using Domain.Models;

namespace BusinessLayer.Abstractions;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetCategoriesAsync();
}
