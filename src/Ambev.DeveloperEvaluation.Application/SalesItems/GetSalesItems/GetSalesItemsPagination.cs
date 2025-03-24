using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using MediatR;

namespace Ambev.DeveloperEvaluation.SaleItems.GetSaleItems;

/// <summary>
/// Command for retrieving all SalesItems
/// </summary>
public class GetSalesItemsPagination : IRequest<PaginatedList<GetSalesItemsResult>>
{
    public GetSalesItemsPagination(int pageNumber, int pageSize)
    {
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
    }

    /// <summary>
    /// Initializes a new instance of GetSalesItemsPagination
    /// </summary>
    public int pageNumber { get; }

    /// <summary>
    /// Initializes a new instance of GetSalesItemsPagination
    /// </summary>
    public int pageSize { get; }
}
