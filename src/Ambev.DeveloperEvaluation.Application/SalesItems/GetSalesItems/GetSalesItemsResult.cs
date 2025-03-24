namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;

/// <summary>
/// Response model for GetSaleItems operation
/// </summary>
public class GetSalesItemsResult
{
    /// <summary>
    /// The unique identifier of the SaleItems
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// The SaleItems's Quantity
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The SaleItems's UnitPrice
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The SaleItems's Discount
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The SaleItems's TotalAmount in the system
    /// </summary>
    public decimal TotalAmount { get; set; }

    
}
