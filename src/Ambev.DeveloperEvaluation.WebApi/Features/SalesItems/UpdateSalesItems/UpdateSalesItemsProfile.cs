using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSalesItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.UpdateSalesItems;

/// <summary>
/// Profile for mapping between Application and API UpdateSalesItems responses
/// </summary>
public class UpdateSalesItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for UpdateSalesItems feature
    /// </summary>
    public UpdateSalesItemsProfile()
    {
        CreateMap<UpdateSalesItemsRequest, UpdateSalesItemsCommand>();
        CreateMap<UpdateSalesItemsResult, UpdateSalesItemsResponse>();
    }
}





