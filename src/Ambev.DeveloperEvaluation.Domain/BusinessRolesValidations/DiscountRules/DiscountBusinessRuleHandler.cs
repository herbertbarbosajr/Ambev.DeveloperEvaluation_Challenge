﻿using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;

public class DiscountBusinessRuleHandler
{
    private readonly IEnumerable<IBusinessRules> _discountRules;

    public DiscountBusinessRuleHandler(IEnumerable<IBusinessRules> discountRules)
    {
        _discountRules = discountRules;
    }

    public void Apply(Sale sale)
    {
        foreach (var item in sale.Items)
        {
            foreach (var rule in _discountRules)
            {
                rule.Apply(item);
            }

            CalculateTotalAmount(item);
        }

        sale.TotalAmount = CalculateSaleTotalAmount(sale);
    }

    private void CalculateTotalAmount(SaleItem item)
    {
        item.TotalAmount = item.Quantity * item.UnitPrice * (1 - item.Discount);
    }

    private decimal CalculateSaleTotalAmount(Sale sale)
    {
        return sale.Items.Sum(i => i.TotalAmount);
    }
}
