using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSalesItems;

public class UpdateSalesItemsCommandHandler : IRequestHandler<UpdateSalesItemsCommand, UpdateSalesItemsResult>
{
    private readonly ISaleItemRepository _saleItemRepository;

    public UpdateSalesItemsCommandHandler(ISaleItemRepository saleItemRepository)
    {
        _saleItemRepository = saleItemRepository;
    }

    public async Task<UpdateSalesItemsResult> Handle(UpdateSalesItemsCommand request, CancellationToken cancellationToken)
    {
        var saleItem = await _saleItemRepository.GetByIdAsync(request.Id, cancellationToken);
        if (saleItem == null)
        {
            throw new KeyNotFoundException($"SaleItem with ID {request.Id} not found.");
        }

        saleItem.ProductId = request.ProductId;
        saleItem.Quantity = request.Quantity;
        saleItem.UnitPrice = request.UnitPrice;
        saleItem.Discount = request.Discount;
        saleItem.TotalAmount = request.TotalAmount;

        await _saleItemRepository.UpdateAsync(saleItem, cancellationToken);

        return new UpdateSalesItemsResult { Id = saleItem.Id };
    }
}



