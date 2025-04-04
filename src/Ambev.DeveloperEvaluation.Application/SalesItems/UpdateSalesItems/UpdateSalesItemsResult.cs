namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSalesItems;

/// <summary>
/// Represents the response returned after successfully updating a SaleItem.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the updated SaleItem,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateSalesItemsResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated SaleItem.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated SaleItem in the system.</value>
    public Guid Id { get; set; }
}



