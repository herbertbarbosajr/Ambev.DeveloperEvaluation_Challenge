namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.CreateSalesItems;

/// <summary>
/// API response model for CreateSalesItems operation
/// </summary>
public class CreateSalesItemsResponse
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
