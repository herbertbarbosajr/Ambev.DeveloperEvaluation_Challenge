using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Salename: Required, length between 3 and 50 characters
    /// - Stock: Cannot be None
    /// - Price: Cannot be null or empty
    /// </remarks>
    public CreateSaleRequestValidator()
    {    
        RuleFor(Sale => Sale.Customer).NotEmpty().Length(3, 50);
        RuleFor(Sale => Sale.Branch).NotEmpty().NotNull();
    }
}