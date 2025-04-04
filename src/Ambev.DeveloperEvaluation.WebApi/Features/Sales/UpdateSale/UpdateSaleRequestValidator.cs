using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest that defines validation rules for Sale creation.
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Salename: Required, length between 3 and 50 characters
    /// - Stock: Cannot be None
    /// - Price: Cannot be null or empty
    /// </remarks>
    public UpdateSaleRequestValidator()
    {    
        RuleFor(Sale => Sale.Customer).NotEmpty().Length(3, 50);
        RuleFor(Sale => Sale.Branch).NotEmpty().NotNull();
    }
}