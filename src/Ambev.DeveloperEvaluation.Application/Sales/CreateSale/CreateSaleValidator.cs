using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleCommand that defines validation rules for Sale creation command.
/// </summary>
public class CreateSaleCommandValidator : AbstractValidator<CreateSaleCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Customer: Required, must be between 3 and 50 characters
    /// - TotalAmount: Cannot be set to null or empty
    /// </remarks>
    public CreateSaleCommandValidator()
    {   
        RuleFor(Sale => Sale.Customer).NotEmpty().Length(3, 50);
        RuleFor(Sale => Sale.TotalAmount).NotEmpty().NotNull();
    }
}