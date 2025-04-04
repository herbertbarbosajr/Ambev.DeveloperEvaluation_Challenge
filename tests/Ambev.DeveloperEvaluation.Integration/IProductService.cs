using Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;
using Ambev.DeveloperEvaluation.Domain.Entities;
using NSubstitute;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration
{
    public interface IProductService
    {
        decimal GetProductPrice(int productId);
    }

    public class SaleItemTests : IClassFixture<DiscountBusinessRuleHandlerFixture>
    {
        private readonly DiscountBusinessRuleHandler _discountBusinessRuleHandler;
        public SaleItemTests(DiscountBusinessRuleHandlerFixture fixture)
        {
            _discountBusinessRuleHandler = fixture.DiscountBusinessRuleHandler;
        }

        [Fact]
        public void CalculateTotal_ShouldReturnCorrectTotal()
        {
            // Arrange
            var productService = Substitute.For<IProductService>();
            productService.GetProductPrice(1).Returns(100.0m);
            var saleItem = new SaleItem
            {
                ProductId = 1,
                Quantity = 5,
                UnitPrice = 100.0m,
                Discount = 0.1m
            };
            // Act
            var total = _discountBusinessRuleHandler.CalculateTotal(saleItem);
            // Assert
            Assert.Equal(450.0m, total);
        }
    }
}
