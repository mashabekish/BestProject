using Domain.Models;

namespace Domain.DataSeeder
{
    public class DbSeeder : IDbSeeder
    {
        private readonly AppDbContext _db;
        public DbSeeder(AppDbContext db)
        {
            _db = db;
        }
        public async Task SeedData()
        {
            // Using EnsureDeleted while in development;
            // TODO: Delete once no changes in schema or data is needed
            _db.Database.EnsureDeleted();
            _db.Database.EnsureCreated();
            await SeedUsers();
            await SeedCategories();
            await SeedItems();
        }
        private async Task SeedUsers()
        {
            if (_db.Users.Any())
                return;

            _db.Users.AddRange(
                new User { Name = "John Doe", Email = "john.doe@example.com", PhoneNumber = "+123456789", Password = "dkmfdk3400011!!@" },
                new User { Name = "Jane Braun", Email = "jane.braun@example.com", PhoneNumber = "+987654321", Password = "drfvm999fd1@#" }
            );
            await _db.SaveChangesAsync();
        }

        private async Task SeedCategories()
        {
            if (_db.Categories.Any())
                return;

            _db.Categories.AddRange(
                new Category { Name = "Keys" },
                new Category { Name = "Glasses" },
                new Category { Name = "Headphones" },
                new Category { Name = "Electronics" },
                new Category { Name = "Clothes" },
                new Category { Name = "Shoes" },
                new Category { Name = "Bags" },
                new Category { Name = "Wallets" },
                new Category { Name = "Accessories" },
                new Category { Name = "Documents" },
                new Category { Name = "Bank cards" }
                );
            await _db.SaveChangesAsync();
        }
        private async Task SeedItems()
        {
            if (_db.Items.Any())
                return;

            // Adding found items
            _db.Items.AddRange(
                new Item
                {
                    CategoryId = 1,
                    Flag = Flags.Found,
                    UserId = 1,
                    Name = "Keys with blue keychain",
                    Description = "Keys found on 01.01.2024 near Rondo Onz tram stop."
                },
                new Item
                {
                    CategoryId = 1,
                    Flag = Flags.Found,
                    UserId = 2,
                    Name = "Big silver key + chip",
                    Description = "Found in Mokotów"
                },
                new Item
                {
                    CategoryId = 9,
                    Flag = Flags.Found,
                    UserId = 1,
                    Name = "Lost Watch",
                    Description = "Black wristwatch found at the shopping mall."
                },
                new Item
                {
                    CategoryId = 9,
                    Flag = Flags.Found,
                    UserId = 2,
                    Name = "Red Umbrella",
                    Description = "Found on the bus, left at the back seat."
                },
                new Item
                {
                    CategoryId = 3,
                    Flag = Flags.Found,
                    UserId = 1,
                    Name = "Found Smartphone",
                    Description = "Found near the coffee shop, please contact if yours."
                },
                new Item
                {
                    CategoryId = 2,
                    Flag = Flags.Found,
                    UserId = 1,
                    Name = "Found Glasses",
                    Description = "Prescription glasses found in the city center."
                },
                //Adding lost items
                new Item
                {
                    CategoryId = 8,
                    Flag = Flags.Lost,
                    UserId = 1,
                    Name = "Missing Wallet",
                    Description = "Lost a brown leather wallet with ID cards and credit cards."
                },
                new Item
                {
                    CategoryId = 4,
                    Flag = Flags.Lost,
                    UserId = 2,
                    Name = "Lost Laptop",
                    Description = "Left a laptop in a black laptop case on the train, reward for return."
                },
                new Item
                {
                    CategoryId = 1,
                    Flag = Flags.Lost,
                    UserId = 2,
                    Name = "Lost Car Keys",
                    Description = "Lost car keys with a keychain near the park entrance."
                },
                new Item
                {
                    CategoryId = 7,
                    Flag = Flags.Lost,
                    UserId = 2,
                    Name = "Missing Backpack",
                    Description = "Blue backpack lost at the bus station, contains important documents."
                },
                new Item
                {
                    CategoryId = 3,
                    Flag = Flags.Lost,
                    UserId = 1,
                    Name = "Lost Headphones",
                    Description = "Left headphones in a black case at the gym, please contact if found."
                },
                new Item
                {
                    CategoryId = 2,
                    Flag = Flags.Lost,
                    UserId = 2,
                    Name = "Lost Sunglasses",
                    Description = "Lost sunglasses with a blue frame on the bench near the park."
                },
                new Item
                {
                    CategoryId = 9,
                    Flag = Flags.Lost,
                    UserId = 1,
                    Name = "Lost Necklace",
                    Description = "Lost a gold necklace with a heart pendant, reward offered."
                }
             );

            await _db.SaveChangesAsync();
        }
    }
}
