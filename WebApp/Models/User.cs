namespace WebApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public Payload Payload { get; set; }

        public User(int id, string name, string email, Payload payload)
        {
            Id = id;
            Name = name;
            Email = email;
            Payload = payload;
        }
    }
}
