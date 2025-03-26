using Ambev.DeveloperEvaluation.Domain.Entities.Registers;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestRegisters
{
    public class SaleRegisterTests
    {
        [Fact]
        public void SaleRegister_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var saleNumber = 123;
            var date = DateTime.UtcNow;

            // Act
            var saleRegister = new SaleRegister
            {
                SaleNumber = saleNumber,
                Date = date
            };

            // Assert
            saleRegister.SaleNumber.Should().Be(saleNumber);
            saleRegister.Date.Should().Be(date);
        }

        [Fact]
        public void SaleRegister_ShouldHaveDefaultValues()
        {
            // Act
            var saleRegister = new SaleRegister();

            // Assert
            saleRegister.SaleNumber.Should().Be(0);
            saleRegister.Date.Should().Be(default);
        }
    }
}
