using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.CreateSalesItems;

/// <summary>
/// Profile for mapping between Application and API CreateSalesItems responses
/// </summary>
public class CreateSalesItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateSalesItems feature
    /// </summary>
    public CreateSalesItemsProfile()
    {
        CreateMap<CreateSalesItemsRequest, CreateSalesItemsCommand>();
        CreateMap<CreateSalesItemsResult, CreateSalesItemsResponse>();
    }
}
