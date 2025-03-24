using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Extensions;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.SaleItems.GetSaleItems;

/// <summary>
/// Profile for mapping GetSale feature requests to commands
/// </summary>
public class GetSalesItemsPaginationProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSale feature
    /// </summary>
    public GetSalesItemsPaginationProfile()
    {
        CreateMap<PaginatedList<SaleItem>, PaginatedList<GetSalesItemsResult>>();
    }
}
