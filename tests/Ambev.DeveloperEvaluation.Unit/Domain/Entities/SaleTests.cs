using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentAssertions;
using Moq;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleTests
{
    [Fact]
    public void Validate_ShouldReturnValidResult_WhenSaleIsValid()
    {
        // Arrange
        var sale = new Sale
        {
            SaleNumber = 123,
            Date = DateTime.UtcNow,
            Customer = "John Doe",
            TotalAmount = 100.0m,
            Branch = "Main Branch",
            Items = new List<SaleItem>(),
            IsCancelled = false
        };

        var validatorMock = new SaleValidator();

        // Act
        var result = validatorMock.Validate(sale);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Validate_ShouldReturnInvalidResult_WhenSaleIsInvalid()
    {
        // Arrange
        var sale = new Sale
        {
            SaleNumber = 0, 
            Date = DateTime.UtcNow,
            Customer = string.Empty,
            TotalAmount = -10.0m,
            Branch = string.Empty,
            Items = new List<SaleItem>(),
            IsCancelled = false
        };

        var validatorMock = new Mock<SaleValidator>();

        // Act
        var result = sale.Validate();

        // Assert
        result.IsValid.Should().BeFalse();
    }

    [Fact]
    public void Activate_ShouldSetIsCancelledToFalse()
    {
        // Arrange
        var sale = new Sale
        {
            IsCancelled = true
        };

        // Act
        sale.Activate();

        // Assert
        sale.IsCancelled.Should().BeFalse();
    }

    [Fact]
    public void Deactivate_ShouldSetIsCancelledToTrue()
    {
        // Arrange
        var sale = new Sale
        {
            IsCancelled = false
        };

        // Act
        sale.Deactivate();

        // Assert
        sale.IsCancelled.Should().BeTrue();
    }
}
