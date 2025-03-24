using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;

public class NoDiscountRule : IBusinessRules
{
    public void Apply(SaleItem item)
    {
        if (item.Quantity < 4)
        {
            item.Discount = 0m;
        }
    }
}
