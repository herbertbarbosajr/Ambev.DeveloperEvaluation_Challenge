using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Specifications;

public class ActiveSaleSpecification : ISpecification<Sale>
{
    public bool IsSatisfiedBy(Sale sale)
    {
        return sale.IsCancelled == false;
    }
}
