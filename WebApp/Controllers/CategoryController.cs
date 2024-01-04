using BusinessLayer.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

[ApiController]
[Route("[Controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet("Get")]
    public async Task<IActionResult> GetCategoriesAsync()
    {
        var response = await _categoryService.GetCategoriesAsync();
        return Ok(response);
    }
}
