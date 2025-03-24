using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.Events
{
    public class SaleItemRegisteredEvent
    {
        public SaleItem SaleItem { get; }

        public SaleItemRegisteredEvent(SaleItem saleItem)
        {
            SaleItem = saleItem;
        }
    }
}
