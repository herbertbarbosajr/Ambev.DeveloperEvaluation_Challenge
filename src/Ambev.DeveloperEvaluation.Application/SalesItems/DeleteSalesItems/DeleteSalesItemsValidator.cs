using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItems;

/// <summary>
/// Validator for DeleteSaleItemsCommand
/// </summary>
public class DeleteSalesItemsValidator : AbstractValidator<DeleteSalesItemsCommand>
{
    /// <summary>
    /// Initializes validation rules for DeleteSaleItemsCommand
    /// </summary>
    public DeleteSalesItemsValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SaleItems ID is required");
    }
}
