using Ambev.DeveloperEvaluation.Domain.Extensions;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Command for retrieving all Sales
/// </summary>
public class GetSalePagination : IRequest<PaginatedList<GetSaleResult>>
{
    public GetSalePagination(int pageNumber, int pageSize)
    {
        this.pageNumber = pageNumber;
        this.pageSize = pageSize;
    }

    /// <summary>
    /// Initializes a new instance of GetSalePagination
    /// </summary>
    public int pageNumber { get; }

    /// <summary>
    /// Initializes a new instance of GetSalePagination
    /// </summary>
    public int pageSize { get; }
}
