using AutoMapper;
using BusinessLayer.Abstractions;
using BusinessLayer.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Exceptions;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Authorize]
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
        private Item MapItemDto(ItemDto dto) => _mapper.Map<Item>(dto);

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

        [HttpGet("GetLostByUser/{userId:int}")]
        public async Task<IActionResult> GetLostItemsByUserAsync(int userId)
        {
            var response = await _itemService.GetLostItemsByUserAsync(userId);
            return Ok(MapItems(response));
        }
        [AllowAnonymous]
        [HttpPost("CreateFound")]
        public async Task<IActionResult> CreateFoundAsync(ItemDto foundItem)
        {
            var newItem = await _itemService.CreateFoundItemAsync(MapItemDto(foundItem));
            var matchingItems = await _itemService.GetMatchingItems(newItem);
            var dto = new CreateItemResponseDto(MapItem(newItem), MapItems(matchingItems));
            return Ok(dto);
        }

        [HttpPost("CreateLost")]
        public async Task<IActionResult> CreateLostAsync(ItemDto lostItem)
        {
            var newItem = await _itemService.CreateLostItemAsync(MapItemDto(lostItem));
            var matchingItems = await _itemService.GetMatchingItems(newItem);
            var dto = new CreateItemResponseDto(MapItem(newItem), MapItems(matchingItems));
            return Ok(dto);
        }

        [HttpPut("Edit/{itemId:int}")]
        public async Task<IActionResult> EditAsync(int itemId, Item editItem)
        {
            if (itemId != editItem.Id) throw new InvalidItemException();

            var response = await _itemService.EditItemAsync(editItem);
            return Ok(MapItem(response));
        }

        [HttpGet("GetResolved")]
        public async Task<IActionResult> GetResolvedItemsAsync()
        {
            var response = await _itemService.GetResolvedItemsAsync();
            return Ok(MapItems(response));
        }

        [Authorize]
        [HttpPut("Location/GetLostItems")]
        public async Task<IActionResult> GetLostItemsByLocation(Location location)
        {
            var response = await _itemService.GetLostItemsByLocation(location);
            return Ok(MapItems(response));
        }

        [Authorize]
        [HttpPut("Location/GetFoundItems")]
        public async Task<IActionResult> GetFoundItemsByLocation(Location location)
        {
            var response = await _itemService.GetFoundItemsByLocation(location);
            return Ok(MapItems(response));
        }

        [AllowAnonymous]
        [HttpGet("{itemId:int}")]
        public async Task<IActionResult> GetItemById(int itemId)
        {
            var item = await _itemService.GetItemById(itemId);
            if (item == null)
                return NotFound("Item with such id is not found");
            return Ok(_mapper.Map<ItemDto>(item));
        }
    }
}
