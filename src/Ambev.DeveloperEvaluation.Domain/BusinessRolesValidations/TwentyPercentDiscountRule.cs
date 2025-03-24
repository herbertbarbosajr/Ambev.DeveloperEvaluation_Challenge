using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;

public class TwentyPercentDiscountRule : IBusinessRules
{
    public void Apply(SaleItem item)
    {
        if (item.Quantity >= 10 && item.Quantity <= 20)
        {
            item.Discount = 0.20m;
        }
    }
}
