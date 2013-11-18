using FluentAssertions;
using NUnit.Framework;
using Service;

namespace ServiceUnitTests
{
    [TestFixture]
    public class InventoryServiceTests
    {
        [Test]
        public void GetItems_NoItemsStored_ReturnEmptyList()
        {
            var service = new InventoryService();

            var result = service.GetProducts();

            result.Should().BeEmpty();
        }
    }

}
