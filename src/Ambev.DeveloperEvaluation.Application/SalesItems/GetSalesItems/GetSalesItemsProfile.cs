using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;

/// <summary>
/// Profile for mapping between SaleItems entity and GetSaleItemsResponse
/// </summary>
public class GetSalesItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSaleItems operation
    /// </summary>
    public GetSalesItemsProfile()
    {
        CreateMap<SaleItem, GetSalesItemsResult>();
    }
}
