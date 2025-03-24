using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.CreateSalesItems;

/// <summary>
/// Validator for CreateSalesItemsRequest that defines validation rules for SalesItems creation.
/// </summary>
public class CreateSalesItemsRequestValidator : AbstractValidator<CreateSalesItemsRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSalesItemsRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Quantity
    /// - UnitPrice
    /// - Discount
    /// - TotalAmount
    /// </remarks>
    public CreateSalesItemsRequestValidator()
    {
        
        RuleFor(SalesItems => SalesItems.Quantity).NotEmpty();
        RuleFor(SalesItems => SalesItems.UnitPrice).NotNull();
        RuleFor(SalesItems => SalesItems.Discount);
        RuleFor(SalesItems => SalesItems.TotalAmount);
    }
}