using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;

/// <summary>
/// Profile for mapping between SaleItems entity and CreateSaleItemsResponse
/// </summary>
public class CreateSalesItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSaleItems operation
    /// </summary>
    public CreateSalesItemsProfile()
    {
        CreateMap<CreateSalesItemsCommand, SaleItem>();
        CreateMap<SaleItem, CreateSalesItemsResult>();
    }
}
