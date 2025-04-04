using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public class UpdateSaleCommandHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;

    public UpdateSaleCommandHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken);
        if (sale == null)
        {
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found.");
        }

        sale.SaleNumber = request.SaleNumber;
        sale.Date = request.Date;
        sale.Customer = request.Customer;
        sale.TotalAmount = request.TotalAmount;
        sale.Branch = request.Branch;
        sale.Items = request.Items;
        sale.IsCancelled = request.IsCancelled;

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return new UpdateSaleResult { Id = sale.Id };
    }
}


