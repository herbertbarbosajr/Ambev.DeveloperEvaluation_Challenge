using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.CreateSalesItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Mappings;

public class CreateSalesItemsRequestProfile : Profile
{
    public CreateSalesItemsRequestProfile()
    {
        CreateMap<CreateSalesItemsRequest, CreateSalesItemsCommand>();
    }
}