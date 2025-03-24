﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {       
              
        RuleFor(saleItem => saleItem.UnitPrice)
            .NotNull()
            .NotEmpty();
        
        RuleFor(saleItem => saleItem.TotalAmount)
            .NotNull()
            .NotEmpty()
            .WithMessage("saleItem status cannot be null or empty.");
    }
}
