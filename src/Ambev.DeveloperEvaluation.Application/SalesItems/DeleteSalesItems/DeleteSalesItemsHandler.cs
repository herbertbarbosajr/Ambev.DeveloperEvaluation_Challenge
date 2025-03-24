using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.EventsPublishers;
using Ambev.DeveloperEvaluation.Domain.Entities.Registers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItems;

/// <summary>
/// Handler for processing DeleteSaleItemsCommand requests
/// </summary>
public class DeleteSalesItemsHandler : IRequestHandler<DeleteSalesItemsCommand, DeleteSalesItemsResponse>
{
    private readonly ISaleItemRepository _SaleItemsRepository;
    private readonly IEventPublisher _eventPublisher;

    /// <summary>
    /// Initializes a new instance of DeleteSaleItemsHandler
    /// </summary>
    /// <param name="SaleItemsRepository">The SaleItems repository</param>
    /// <param name="validator">The validator for DeleteSaleItemsCommand</param>
    public DeleteSalesItemsHandler(
        ISaleItemRepository SaleItemsRepository, 
        IEventPublisher eventPublisher)
    {
        _SaleItemsRepository = SaleItemsRepository;
        _eventPublisher = eventPublisher;
    }

    /// <summary>
    /// Handles the DeleteSaleItemsCommand request
    /// </summary>
    /// <param name="request">The DeleteSaleItems command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSalesItemsResponse> Handle(DeleteSalesItemsCommand request, CancellationToken cancellationToken)
    {
        var validator = new DeleteSalesItemsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _SaleItemsRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"SaleItems with ID {request.Id} not found");

        var deletedSaleItemsEvent = new CancelItem { SaleId = request.Id, CancelDate = DateTime.UtcNow };
        await _eventPublisher.PublishAsync(deletedSaleItemsEvent, cancellationToken);

        return new DeleteSalesItemsResponse { Success = true };
    }
}
