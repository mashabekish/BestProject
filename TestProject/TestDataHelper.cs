using Domain.Models;

namespace Library.BusinessLogicTest;

public static class TestDataHelper
{
    public static Task<IEnumerable<Item>> GetFakeLostItems()
    {
        var items = new List<Item>()
        {
            new() {
                Id = 1,
                Name = "Name1",
                Description = "Description1",
                CategoryId = 1,
                UserId = 1,
                Flag = Flags.Lost,
                IsResolved = false,
                Location = new Location()
                {
                    Latitude = (float)52.2355918884277,
                    Longitude = (float)20.9918956756592,
                    RadiusMeters = 39
                }
            }
        };
        return Task.FromResult(items.AsEnumerable());
    }

    public static Task<IEnumerable<Item>> GetFakeFoundItems()
    {
        var items = new List<Item>()
        {
            new() {
                Id = 2,
                Name = "Name2",
                Description = "Description2",
                CategoryId = 2,
                UserId = 2,
                Flag = Flags.Found,
                IsResolved = false,
                Location = new Location()
                {
                    Latitude = (float)52.2366676330566,
                    Longitude = (float)20.9914932250977,
                    RadiusMeters = 133
                }
            }
        };
        return Task.FromResult(items.AsEnumerable());
    }
}
