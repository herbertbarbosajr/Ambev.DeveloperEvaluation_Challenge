namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.CreateSalesItems;

/// <summary>
/// Represents a request to create a new SalesItems in the system.
/// </summary>
public class CreateSalesItemsRequest
{

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