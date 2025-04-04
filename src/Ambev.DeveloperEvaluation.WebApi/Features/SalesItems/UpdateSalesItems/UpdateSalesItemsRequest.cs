namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.UpdateSalesItems;

/// <summary>
/// Request for updating an existing SaleItem.
/// </summary>
public class UpdateSalesItemsRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the SaleItem to be updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the ProductId of the SaleItem to be updated.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets Quantity for the SaleItem.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the UnitPrice for the SaleItem.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the Discount for the SaleItem.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets TotalAmount of the SaleItem.
    /// </summary>
    public decimal TotalAmount { get; set; }
}





