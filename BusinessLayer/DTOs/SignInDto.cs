using System.ComponentModel.DataAnnotations;

namespace BusinessLayer.DTOs
{
    public class SignInDto
    {
        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [MinLength(8)]
        [MaxLength(255)]
        public string Password { get; set; }
    }
}
