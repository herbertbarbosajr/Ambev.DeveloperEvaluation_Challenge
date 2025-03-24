using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// API response model for GetSale operation
/// </summary>
public class GetSaleResponse
{
    /// <summary>
    /// The unique identifier of the Sale
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The Sale's SaleNumber
    /// </summary>
    public int SaleNumber { get; set; }

    /// <summary>
    /// The Sale's Date
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The current Customer of the Sale
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// The current TotalAmount of the Sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The current Branch of the Sale
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The current List of Items of the Sale
    /// </summary>
    public List<SaleItem> Items { get; set; }

    /// <summary>
    /// The current IsCancelled of Items of the Sale
    /// </summary>
    public bool IsCancelled { get; set; }
}
