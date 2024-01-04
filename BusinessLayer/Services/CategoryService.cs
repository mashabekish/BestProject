using BusinessLayer.Abstractions;
using Domain.Abstractions;
using Domain.Models;

namespace BusinessLayer.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<Category>> GetCategoriesAsync()
    {
        return await _categoryRepository.GetCategoriesAsync();
    }
}
