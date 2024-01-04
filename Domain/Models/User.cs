using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    public class User
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Name { get; set; }
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }
        [MinLength(8)]
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(16)]
        public string? PhoneNumber { get; set; }
        public IEnumerable<Item>? Items { get; set; }
        public List<Notification>? Notifications { get; set; }
    }
}
