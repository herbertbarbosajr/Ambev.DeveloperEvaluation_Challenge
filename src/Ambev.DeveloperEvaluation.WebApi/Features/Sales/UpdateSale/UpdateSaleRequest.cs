using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Request for updating an existing Sale.
/// </summary>
public class UpdateSaleRequest
{
    /// <summary>
    /// Gets or sets the unique identifier of the Sale to be updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the SaleNumber of the Sale to be updated.
    /// </summary>
    public int SaleNumber { get; set; }

    /// <summary>
    /// Gets or sets the Date for the Sale.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the Customer of the Sale.
    /// </summary>
    public string Customer { get; set; }

    /// <summary>
    /// Gets or sets the TotalAmount of the Sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the Branch of the Sale
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Gets or sets the list of Items of the Sale
    /// </summary>
    public List<SaleItem> Items { get; set; }

    /// <summary>
    /// Gets or sets the IsCancelled status of the Sale
    /// </summary>
    public bool IsCancelled { get; set; }
}




