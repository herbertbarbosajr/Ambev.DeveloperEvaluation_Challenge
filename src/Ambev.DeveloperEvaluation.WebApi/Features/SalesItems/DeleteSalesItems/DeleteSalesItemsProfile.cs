using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItems;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.DeleteSalesItems;

/// <summary>
/// Profile for mapping DeleteSalesItems feature requests to commands
/// </summary>
public class DeleteSalesItemsProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for DeleteSalesItems feature
    /// </summary>
    public DeleteSalesItemsProfile()
    {
        CreateMap<Guid, DeleteSalesItemsCommand>()
            .ConstructUsing(id => new DeleteSalesItemsCommand(id));
    }
}
