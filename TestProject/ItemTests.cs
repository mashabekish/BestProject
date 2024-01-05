using BusinessLayer.Abstractions;
using BusinessLayer.Services;
using Domain.Abstractions;
using Library.BusinessLogicTest;
using Moq;

namespace TestProject
{
    public class ItemTests
    {
        private IItemService _itemService;

        [SetUp]
        public void Setup()
        {
            var repositoryMock = new Mock<IItemRepository>();

            var lostItems = TestDataHelper.GetFakeLostItems();
            repositoryMock.Setup(m => m.GetLostItemsAsync()).Returns(lostItems);

            var foundItems = TestDataHelper.GetFakeFoundItems();
            repositoryMock.Setup(m => m.GetFoundItemsAsync()).Returns(foundItems);

            _itemService = new ItemService(repositoryMock.Object);
        }

        [TestCase(1)]
        public async Task GetLostTestAsync(int count)
        {
            var items = await _itemService.GetLostItemsAsync();
            Assert.That(count, Is.EqualTo(items.Count()));
        }

        [TestCase(1)]
        public async Task GetFoundTestAsync(int count)
        {
            var items = await _itemService.GetFoundItemsAsync();
            Assert.That(count, Is.EqualTo(items.Count()));
        }
    }
}
