using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.DeleteSalesItems;

/// <summary>
/// Validator for DeleteSalesItemsRequest
/// </summary>
public class DeleteSalesItemsRequestValidator : AbstractValidator<DeleteSalesItemsRequest>
{
    /// <summary>
    /// Initializes validation rules for DeleteSalesItemsRequest
    /// </summary>
    public DeleteSalesItemsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SalesItems ID is required");
    }
}
