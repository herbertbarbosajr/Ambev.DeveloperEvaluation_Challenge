namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSalesItems;

/// <summary>
/// Request model for getting a Sale by Pagination
/// </summary>
public class GetSalesItemsRequestPagination
{
    /// <summary>
    /// The pagination of the Sale to retrieve
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// The pagination of the Sale to retrieve
    /// </summary>
    public int PageSize { get; set; }
}
