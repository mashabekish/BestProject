﻿using BusinessLayer.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [AllowAnonymous]
        [HttpGet("Get")]
        public async Task<IActionResult> GetCategoriesAsync()
        {
            var response = await _categoryService.GetCategoriesAsync();
            return Ok(response);
        }
    }
}
