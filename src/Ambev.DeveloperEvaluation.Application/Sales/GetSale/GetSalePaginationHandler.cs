using AutoMapper;
using MediatR;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Extensions;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Handler for processing GetSalePagination requests
/// </summary>
public class GetSalePaginationHandler : IRequestHandler<GetSalePagination, PaginatedList<GetSaleResult>>
{
    private readonly ISaleRepository _SaleRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSalePaginationHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetSalePagination</param>
    public GetSalePaginationHandler(
        ISaleRepository SaleRepository,
        IMapper mapper)
    {
        _SaleRepository = SaleRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the Get All Sales
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PaginatedList<GetSaleResult>> Handle(GetSalePagination request, CancellationToken cancellationToken)
    {
        var sales = await _SaleRepository.GetAllSales(request.pageNumber, request.pageSize);

        if (sales == null)
        {
            throw new KeyNotFoundException("Sales not found");
        }

        return _mapper.Map<PaginatedList<GetSaleResult>>(sales);
    }
}
