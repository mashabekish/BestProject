using BusinessLayer.Abstractions;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Exceptions;

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
        [HttpGet("GetFoundByCategory/{categoryId:int}")]
        public async Task<IActionResult> GetFoundItemsByCategoteryAsync(int categoryId)
        {
            var response = await _itemService.GetFoundItemsByCategoryAsync(categoryId);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetFoundByUser/{userId:int}")]
        public async Task<IActionResult> GetFoundItemsByUserAsync(int userId)
        {
            var response = await _itemService.GetFoundItemsByUserAsync(userId);
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
        [HttpGet("GetLostByCategory/{categoryId:int}")]
        public async Task<IActionResult> GetLostItemsAsync(int categoryId)
        {
            var response = await _itemService.GetLostItemsByCategoryAsync(categoryId);
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpGet("GetLostByUser/{userId:int}")]
        public async Task<IActionResult> GetLostItemsByUserAsync(int userId)
        {
            var response = await _itemService.GetLostItemsByUserAsync(userId);
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
        [HttpPut("Edit/{userId:int}")]
        public async Task<IActionResult> EditAsync(int userId, Item editItem)
        {
            if (userId != editItem.Id) throw new InvalidItemException();

            var response = await _itemService.EditItemAsync(editItem);
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
