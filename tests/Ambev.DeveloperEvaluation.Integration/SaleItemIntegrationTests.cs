using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;
using Ambev.DeveloperEvaluation.ORM;
using Moq;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Integration
{
    public class SaleItemIntegrationTests
    {
        private DbContextOptions<DefaultContext> CreateInMemoryDatabaseOptions()
        {
            return new DbContextOptionsBuilder<DefaultContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public void Should_Add_SaleItem_To_Database()
        {
            // Arrange
            var options = CreateInMemoryDatabaseOptions();
            using var context = new DefaultContext(options);
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(ps => ps.GetProductPrice(It.IsAny<int>())).Returns(100.0m);

            var saleItem = new SaleItem()
            {
                ProductId = 1,
                Quantity = 10,
                UnitPrice = 100.0m,
                Discount = 5.0m,
                TotalAmount = 950.0m,
                SaleId = Guid.NewGuid()
            };

            // Act
            context.SaleItems.Add(saleItem);
            context.SaveChanges();

            // Assert
            var savedSaleItem = context.SaleItems.FirstOrDefault(si => si.ProductId == 1);
            savedSaleItem.Should().NotBeNull();
            savedSaleItem.Quantity.Should().Be(10);
            savedSaleItem.UnitPrice.Should().Be(100.0m);
            savedSaleItem.Discount.Should().Be(5.0m);
            savedSaleItem.TotalAmount.Should().Be(950.0m);
        }
    }
}
