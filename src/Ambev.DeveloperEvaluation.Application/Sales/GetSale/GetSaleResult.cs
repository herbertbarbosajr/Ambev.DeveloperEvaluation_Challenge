using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Response model for GetSale operation
/// </summary>
public class GetSaleResult
{
    /// <summary>
    /// The unique identifier of the Sale
    /// </summary>
    public int SaleNumber { get; set; }

    /// <summary>
    /// The Sale's Date
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// The Sale's Customer
    /// </summary>
    public string Customer { get; set; }

    /// <summary>
    /// The current TotalAmount of the Sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// The current Branch of the Sale
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// The current Items of the Sale
    /// </summary>
    public List<SaleItem> Items { get; set; }

    /// <summary>
    /// The current Items is canceled of the Sale
    /// </summary>
    public bool IsCancelled { get; set; }
}
