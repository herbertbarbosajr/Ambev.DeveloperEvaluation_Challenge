namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSalesItems;

/// <summary>
/// Request model for getting a SalesItems by ID
/// </summary>
public class GetSalesItemsRequest
{
    /// <summary>
    /// The unique identifier of the SalesItems to retrieve
    /// </summary>
    public Guid Id { get; set; }
}
