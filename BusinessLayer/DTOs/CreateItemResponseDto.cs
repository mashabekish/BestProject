using BusinessLayer.DTOs;
using Domain.Models;

namespace WebApp.Models
{
    public class CreateItemResponseDto
    {
        public CreateItemResponseDto(ItemDto newItem, IEnumerable<ItemDto> matchingItems)
        {
            NewItem = newItem;
            MatchingItems = matchingItems;
        }

        public ItemDto NewItem { get; set; }
        public IEnumerable<ItemDto> MatchingItems { get; set; } = new List<ItemDto>();
    }
}
