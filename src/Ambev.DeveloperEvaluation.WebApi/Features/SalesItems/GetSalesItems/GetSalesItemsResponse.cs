namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSalesItems;

/// <summary>
/// API response model for GetSalesItems operation
/// </summary>
public class GetSalesItemsResponse
{
    /// <summary>
    /// The unique identifier of the created SalesItems
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The SalesItems's Quantity
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The SalesItems's UnitPrice
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The SalesItems's Discount
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The current TotalAmount of the SalesItems
    /// </summary>
    public decimal TotalAmount { get; set; }
}
