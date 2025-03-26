using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities;

public class SaleItemTests
{
    [Fact]
    public void Validate_ShouldReturnValidResult_WhenSaleItemIsValid()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            ProductId = 1,
            Quantity = 10,
            UnitPrice = 100.0m,
            Discount = 10.0m,
            TotalAmount = 900.0m,
            SaleId = Guid.NewGuid()
        };

        var validator = new SaleItemValidator();

        // Act
        var result = validator.Validate(saleItem);

        // Assert
        result.IsValid.Should().BeTrue();
        result.Errors.Should().BeEmpty();
    }



    [Fact]
    public void Validate_ShouldReturnInvalidResult_WhenSaleItemIsInvalid()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            ProductId = 0,
            Quantity = -1,
            UnitPrice = 0,
            Discount = -10.0m,
            TotalAmount = -900.0m,
            SaleId = Guid.NewGuid()
        };

        var validator = new SaleItemValidator();

        // Act
        var result = validator.Validate(saleItem);

        // Assert
        result.IsValid.Should().BeFalse();
        
    }

}
