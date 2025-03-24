using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;

public class TenPercentDiscountRule : IBusinessRules
{
    public void Apply(SaleItem item)
    {
        if (item.Quantity >= 4 && item.Quantity < 10)
        {
            item.Discount = 0.10m;
        }
    }
}
