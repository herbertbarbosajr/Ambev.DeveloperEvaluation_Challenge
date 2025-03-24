using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// API response model for CreateSale operation
/// </summary>
public class CreateSaleResponse
{
    /// <summary>
    /// Gets or sets the SaleNumber. Must be unique and contain only valid characters.
    /// </summary>
    public int SaleNumber { get; set; }


    /// <summary>
    /// Gets or sets the Date of the Sale.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the Customer to the Sale.
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the TotalAmount to the Sale.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the Branch to the Sale.
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Gets or sets the list of Items to the Sale.
    /// </summary>
    public List<SaleItem> Items { get; set; }

    /// <summary>
    /// Gets or sets the Cancelled to the Sale.
    /// </summary>
    public bool IsCancelled { get; set; }
}
