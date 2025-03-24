namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.DeleteSalesItems;

/// <summary>
/// Request model for deleting a SalesItems
/// </summary>
public class DeleteSalesItemsRequest
{
    /// <summary>
    /// The unique identifier of the SalesItems to delete
    /// </summary>
    public Guid Id { get; set; }
}
