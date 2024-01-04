using BusinessLayer.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [AllowAnonymous]
        [HttpGet("GetFound")]
        public async Task<IActionResult> GetFoundItemsAsync()
        {
            var response = await _itemService.GetFoundItemsAsync();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetFound/{category}")]
        public async Task<IActionResult> GetFoundItemsAsync(string category)
        {
            var response = await _itemService.GetFoundItemsAsync(category);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetLost")]
        public async Task<IActionResult> GetLostItemsAsync()
        {
            var response = await _itemService.GetLostItemsAsync();
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetLost/{category}")]
        public async Task<IActionResult> GetLostItemsAsync(string category)
        {
            var response = await _itemService.GetLostItemsAsync(category);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("CreateFound")]
        public async Task<IActionResult> CreateFoundAsync(Item foundItem)
        {
            var response = await _itemService.CreateFoundItemAsync(foundItem);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("CreateLost")]
        public async Task<IActionResult> CreateLostAsync(Item lostItem)
        {
            var response = await _itemService.CreateLostItemAsync(lostItem);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetResolved")]
        public async Task<IActionResult> GetResolvedItemsAsync()
        {
            var response = await _itemService.GetResolvedItemsAsync();
            return Ok(response);
        }
    }
}
