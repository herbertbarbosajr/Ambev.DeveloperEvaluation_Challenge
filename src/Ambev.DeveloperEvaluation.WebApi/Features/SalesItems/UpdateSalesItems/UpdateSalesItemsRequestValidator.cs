using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.UpdateSalesItems;

/// <summary>
/// Validator for UpdateSalesItems that defines validation rules for Sale creation.
/// </summary>
public class UpdateSalesItemsRequestValidator : AbstractValidator<UpdateSalesItemsRequest>
{
    /// <summary>
    /// Initializes a new instance of the UpdateSalesItemsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Salename: Required, length between 3 and 50 characters
    /// - Stock: Cannot be None
    /// - Price: Cannot be null or empty
    /// </remarks>
    public UpdateSalesItemsRequestValidator()
    {    
        RuleFor(Sale => Sale.Quantity).NotEmpty();

    }
}