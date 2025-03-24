using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItems;

/// <summary>
/// Command for deleting a SaleItems
/// </summary>
public record DeleteSalesItemsCommand : IRequest<DeleteSalesItemsResponse>
{
    /// <summary>
    /// The unique identifier of the SaleItems to delete
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of DeleteSaleItemsCommand
    /// </summary>
    /// <param name="id">The ID of the SaleItems to delete</param>
    public DeleteSalesItemsCommand(Guid id)
    {
        Id = id;
    }
}
