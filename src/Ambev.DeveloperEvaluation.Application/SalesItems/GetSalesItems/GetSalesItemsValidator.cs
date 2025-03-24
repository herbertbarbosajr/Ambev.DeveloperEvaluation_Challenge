using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;

/// <summary>
/// Validator for GetSaleItemsCommand
/// </summary>
public class GetSaleItemsValidator : AbstractValidator<GetSalesItemsCommand>
{
    /// <summary>
    /// Initializes validation rules for GetSaleItemsCommand
    /// </summary>
    public GetSaleItemsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleItems ID is required");
    }
}
