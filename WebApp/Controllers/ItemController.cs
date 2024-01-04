using AutoMapper;
using BusinessLayer.Abstractions;
using BusinessLayer.DTOs;
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
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IMapper mapper)
        {
            _itemService = itemService;
            _mapper = mapper;
        }

        private ItemDto MapItem(Item item) => _mapper.Map<ItemDto>(item);
        private IEnumerable<ItemDto> MapItems(IEnumerable<Item> items) => items.Select(i => _mapper.Map<ItemDto>(i));

        [AllowAnonymous]
        [HttpGet("GetFound")]
        public async Task<IActionResult> GetFoundItemsAsync()
        {
            var response = await _itemService.GetFoundItemsAsync();
            return Ok(MapItems(response));
        }

        [AllowAnonymous]
        [HttpGet("GetFoundByCategory/{categoryId:int}")]
        public async Task<IActionResult> GetFoundItemsByCategoteryAsync(int categoryId)
        {
            var response = await _itemService.GetFoundItemsByCategoryAsync(categoryId);
            return Ok(MapItems(response));
        }

        [AllowAnonymous]
        [HttpGet("GetFoundByUser/{userId:int}")]
        public async Task<IActionResult> GetFoundItemsByUserAsync(int userId)
        {
            var response = await _itemService.GetFoundItemsByUserAsync(userId);
            return Ok(MapItems(response));
        }

        [AllowAnonymous]
        [HttpGet("GetLost")]
        public async Task<IActionResult> GetLostItemsAsync()
        {
            var response = await _itemService.GetLostItemsAsync();
            return Ok(MapItems(response));
        }

        [AllowAnonymous]
        [HttpGet("GetLostByCategory/{categoryId:int}")]
        public async Task<IActionResult> GetLostItemsAsync(int categoryId)
        {
            var response = await _itemService.GetLostItemsByCategoryAsync(categoryId);
            return Ok(MapItems(response));
        }

        [AllowAnonymous]
        [HttpGet("GetLostByUser/{userId:int}")]
        public async Task<IActionResult> GetLostItemsByUserAsync(int userId)
        {
            var response = await _itemService.GetLostItemsByUserAsync(userId);
            return Ok(MapItems(response));
        }

        [AllowAnonymous]
        [HttpPost("CreateFound")]
        public async Task<IActionResult> CreateFoundAsync(Item foundItem)
        {
            var response = await _itemService.CreateFoundItemAsync(foundItem);
            return Ok(MapItem(response));
        }

        [AllowAnonymous]
        [HttpPost("CreateLost")]
        public async Task<IActionResult> CreateLostAsync(Item lostItem)
        {
            var response = await _itemService.CreateLostItemAsync(lostItem);
            return Ok(MapItem(response));
        }

        [AllowAnonymous]
        [HttpPut("Edit/{userId:int}")]
        public async Task<IActionResult> EditAsync(int userId, Item editItem)
        {
            if (userId != editItem.Id) throw new InvalidItemException();

            var response = await _itemService.EditItemAsync(editItem);
            return Ok(MapItem(response));
        }

        [AllowAnonymous]
        [HttpGet("GetResolved")]
        public async Task<IActionResult> GetResolvedItemsAsync()
        {
            var response = await _itemService.GetResolvedItemsAsync();
            return Ok(MapItems(response));
        }

        [Authorize]
        [HttpPut("Locaton/GetLostItems")]
        public async Task<IActionResult> GetLostItemsByLocation(Location location)
        {
            var response = await _itemService.GetLostItemsByLocation(location);
            return Ok(MapItems(response));
        }

        [Authorize]
        [HttpPut("Locaton/GetFoundItems")]
        public async Task<IActionResult> GetFoundItemsByLocation(Location location)
        {
            var response = await _itemService.GetFoundItemsByLocation(location);
            return Ok(MapItems(response));
        }

    }
}
