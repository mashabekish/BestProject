using Domain.Models;

namespace WebApp.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Payload Payload { get; set; }

        public UserDto(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Email = user.Email;
            Payload = new Payload(token);
        }
    }
}
