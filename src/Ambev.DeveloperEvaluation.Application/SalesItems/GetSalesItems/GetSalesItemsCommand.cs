using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;

/// <summary>
/// Command for retrieving a SaleItems by their ID
/// </summary>
public record GetSalesItemsCommand : IRequest<GetSalesItemsResult>
{
    /// <summary>
    /// The unique identifier of the SaleItems to retrieve
    /// </summary>
    public Guid Id { get; }

    /// <summary>
    /// Initializes a new instance of GetSaleItemsCommand
    /// </summary>
    /// <param name="id">The ID of the SaleItems to retrieve</param>
    public GetSalesItemsCommand(Guid id)
    {
        Id = id;
    }
}
