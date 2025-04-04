namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Represents the response returned after successfully updating a Sale.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the updated Sale,
/// which can be used for subsequent operations or reference.
/// </remarks>
public class UpdateSaleResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the updated Sale.
    /// </summary>
    /// <value>A GUID that uniquely identifies the updated Sale in the system.</value>
    public Guid Id { get; set; }
}


