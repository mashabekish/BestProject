using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SignInDto
    {
        [MinLength(5)]
        [MaxLength(255)]
        public string Email { get; set; } = null!;

        [MinLength(5)]
        [MaxLength(255)]
        public string Password { get; set; } = null!;
    }
}
