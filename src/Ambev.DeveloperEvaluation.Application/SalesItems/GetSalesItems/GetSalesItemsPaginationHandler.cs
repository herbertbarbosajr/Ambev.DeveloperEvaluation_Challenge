using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using Ambev.DeveloperEvaluation.SaleItems.GetSaleItems;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;

/// <summary>
/// Handler for processing GetSalePagination requests
/// </summary>
public class GetSalesItemsPaginationHandler : IRequestHandler<GetSalesItemsPagination, PaginatedList<GetSalesItemsResult>>
{
    private readonly ISaleItemRepository _saleItemRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSalesItemsPaginationHandler
    /// </summary>
    /// <param name="SaleRepository">The Sale repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetSalePagination</param>
    public GetSalesItemsPaginationHandler(
        ISaleItemRepository saleItemRepository,
        IMapper mapper)
    {
        _saleItemRepository = saleItemRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the Get All Sales
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    public async Task<PaginatedList<GetSalesItemsResult>> Handle(GetSalesItemsPagination request, CancellationToken cancellationToken)
    {
        var sales = await _saleItemRepository.GetAllSalesItems(request.pageNumber, request.pageSize);

        if (sales == null)
        {
            throw new KeyNotFoundException("Sales not found");
        }

        return _mapper.Map<PaginatedList<GetSalesItemsResult>>(sales);
    }
}
