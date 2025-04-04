using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSalesItems;

public class UpdateSalesItemsCommandValidator : AbstractValidator<UpdateSalesItemsCommand>
{
    public UpdateSalesItemsCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty().WithMessage("SaleItem ID is required.");
        RuleFor(x => x.ProductId).GreaterThan(0).WithMessage("Product ID must be greater than 0.");
        RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than 0.");
        RuleFor(x => x.Discount).GreaterThanOrEqualTo(0).WithMessage("Discount must be greater than or equal to 0.");
        RuleFor(x => x.TotalAmount).GreaterThanOrEqualTo(0).WithMessage("Total amount must be greater than or equal to 0.");
    }
}



