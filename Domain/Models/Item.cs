using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class Item
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime Created { get; set; } = DateTime.UtcNow;
        [MaxLength(255)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public Flags Flag { get; set; }
        public bool IsResolved { get; set; } = false;
        public Location Location { get; set; }
        public int? ImageId { get; set; }
        public Image? Image { get; set; }
        public List<Notification>? Notifications { get; set; }
    }
}
