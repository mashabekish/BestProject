using Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs
{
    public class ItemDto
    {
        public int Id { get; set; }
        public DateTime? Created { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        public Flags Flag { get; set; }
        public bool IsResolved { get; set; } = false;
        public Location Location { get; set; }
        public ImageDto? Image { get; set; }
        public List<Notification>? Notifications { get; set; }

    }
}
