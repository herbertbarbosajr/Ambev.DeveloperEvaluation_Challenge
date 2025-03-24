using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.EventsPublishers;
using Ambev.DeveloperEvaluation.Domain.Entities.Registers;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Handler for processing DeleteSaleCommand requests
/// </summary>
public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, DeleteSaleResponse>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IValidator<DeleteSaleCommand> _validator;
    private readonly IEventPublisher _eventPublisher;

    /// <summary>
    /// Initializes a new instance of DeleteSaleHandler
    /// </summary>
    /// <param name="saleRepository">The Sale repository</param>
    /// <param name="validator">The validator for DeleteSaleCommand</param>
    public DeleteSaleHandler(
        ISaleRepository saleRepository,
        IValidator<DeleteSaleCommand> validator,
        IEventPublisher eventPublisher)
    {
        _saleRepository = saleRepository;
        _validator = validator;
        _eventPublisher = eventPublisher;
    }

    /// <summary>
    /// Handles the DeleteSaleCommand request
    /// </summary>
    /// <param name="request">The DeleteSale command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The result of the delete operation</returns>
    public async Task<DeleteSaleResponse> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var success = await _saleRepository.DeleteAsync(request.Id, cancellationToken);
        if (!success)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
        var deletedSaleEvent = new CancelSaleRegister { SaleNumber = request.Id, CancelDate = DateTime.UtcNow };
        await _eventPublisher.PublishAsync(deletedSaleEvent, cancellationToken);

        return new DeleteSaleResponse { Success = true };
    }
}