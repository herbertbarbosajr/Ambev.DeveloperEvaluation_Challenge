using Xunit;
using FluentAssertions;
using FluentValidation.TestHelper;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Validation;

public class SaleValidatorTests
{
    private readonly SaleValidator _validator;

    public SaleValidatorTests()
    {
        _validator = new SaleValidator();
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenCustomerIsEmpty()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = string.Empty,
            IsCancelled = false
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(sale => sale.Customer);
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenCustomerIsTooShort()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = "Jo",
            IsCancelled = false
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(sale => sale.Customer)
              .WithErrorMessage("customer must be at least 3 characters long.");
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenCustomerIsTooLong()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = new string('A', 51),
            IsCancelled = false
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(sale => sale.Customer)
              .WithErrorMessage("customer cannot be longer than 50 characters.");
    }

    [Fact]
    public void Validate_ShouldNotHaveError_WhenCustomerIsValid()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = "John Doe",
            IsCancelled = false
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveValidationErrorFor(sale => sale.Customer);
    }

    [Fact]
    public void Validate_ShouldHaveError_WhenIsCancelledIsTrue()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = "John Doe",
            IsCancelled = true
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldHaveValidationErrorFor(sale => sale.IsCancelled)
              .WithErrorMessage("Sale status cannot be Unknown.");
    }

    [Fact]
    public void Validate_ShouldNotHaveError_WhenIsCancelledIsFalse()
    {
        // Arrange
        var sale = new Sale
        {
            Customer = "John Doe",
            IsCancelled = false
        };

        // Act
        var result = _validator.TestValidate(sale);

        // Assert
        result.ShouldNotHaveValidationErrorFor(sale => sale.IsCancelled);
    }
}



