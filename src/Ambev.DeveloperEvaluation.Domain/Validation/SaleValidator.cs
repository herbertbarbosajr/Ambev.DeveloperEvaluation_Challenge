using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
       

        RuleFor(sale => sale.Customer)
            .NotEmpty()
            .MinimumLength(3).WithMessage("customer must be at least 3 characters long.")
            .MaximumLength(50).WithMessage("customer cannot be longer than 50 characters.");
         
        RuleFor(sale => sale.IsCancelled)
            .NotEqual(true)
            .WithMessage("Sale status cannot be Unknown.");
        
    }
}
