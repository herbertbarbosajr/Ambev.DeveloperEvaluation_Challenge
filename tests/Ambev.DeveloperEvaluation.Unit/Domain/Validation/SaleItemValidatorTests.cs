using Xunit;
using FluentAssertions;
using FluentValidation.TestHelper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class SaleItemValidatorTests
{
    private readonly SaleItemValidator _validator;

    public SaleItemValidatorTests()
    {
        _validator = new SaleItemValidator();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenUnitPriceIsNull()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            UnitPrice = 0,
            TotalAmount = 100.0m
        };

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldHaveValidationErrorFor(saleItem => saleItem.UnitPrice);
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenTotalAmountIsNull()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            UnitPrice = 100.0m,
            TotalAmount = 0
        };

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldHaveValidationErrorFor(saleItem => saleItem.TotalAmount);
    }

    [Fact]
    public void Validate_ShouldNotHaveError_WhenSaleItemIsValid()
    {
        // Arrange
        var saleItem = new SaleItem
        {
            UnitPrice = 100.0m,
            TotalAmount = 100.0m
        };

        // Act
        var result = _validator.TestValidate(saleItem);

        // Assert
        result.ShouldNotHaveValidationErrorFor(saleItem => saleItem.UnitPrice);
        result.ShouldNotHaveValidationErrorFor(saleItem => saleItem.TotalAmount);
    }
}


