using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSalesItems;

/// <summary>
/// Validator for GetSalesItemsRequest
/// </summary>
public class GetSalesItemsRequestValidator : AbstractValidator<GetSalesItemsRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSalesItemsRequest
    /// </summary>
    public GetSalesItemsRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("SalesItems ID is required");
    }
}
