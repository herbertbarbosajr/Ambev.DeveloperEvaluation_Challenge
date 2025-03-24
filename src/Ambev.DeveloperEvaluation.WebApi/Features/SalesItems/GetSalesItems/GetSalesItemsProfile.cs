using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSalesItems;

/// <summary>
/// Profile for mapping GetSalesItems feature requests to commands
/// </summary>
public class GetSalesItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetSalesItems feature
    /// </summary>
    public GetSalesItemsProfile()
    {
        CreateMap<Guid, GetSalesItemsCommand>()
            .ConstructUsing(id => new GetSalesItemsCommand(id))
            .ReverseMap();
    }
}
