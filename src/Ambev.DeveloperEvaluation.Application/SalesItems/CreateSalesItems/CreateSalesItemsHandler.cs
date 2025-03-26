using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Application.EventsPublishers;
using Ambev.DeveloperEvaluation.Domain.Entities.Registers;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;

/// <summary>
/// Handler for processing CreateSaleItemsCommand requests
/// </summary>
public class CreateSalesItemsHandler : IRequestHandler<CreateSalesItemsCommand, CreateSalesItemsResult>
{
    private readonly ISaleItemRepository _SaleItemsRepository;
    private readonly IMapper _mapper;
    private readonly IEventPublisher _eventPublisher;
    private readonly IValidator<CreateSalesItemsCommand> _validator;


    /// <summary>
    /// Initializes a new instance of CreateSaleItemsHandler
    /// </summary>
    /// <param name="SaleItemsRepository">The SaleItems repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleItemsCommand</param>
    public CreateSalesItemsHandler(ISaleItemRepository SaleItemsRepository,
        IMapper mapper,
        IEventPublisher eventPublisher,
        IValidator<CreateSalesItemsCommand> validator)
    {
        _SaleItemsRepository = SaleItemsRepository;
        _mapper = mapper;
        _eventPublisher = eventPublisher;
        _validator = validator;
    }

    /// <summary>
    /// Handles the CreateSaleItemsCommand request
    /// </summary>
    /// <param name="command">The CreateSaleItems command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SaleItems details</returns>
    public async Task<CreateSalesItemsResult> Handle(CreateSalesItemsCommand command, CancellationToken cancellationToken)
    {
       
        var validationResult = await _validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var SaleItems = _mapper.Map<SaleItem>(command);
        
        var createdSaleItems = await _SaleItemsRepository.CreateAsync(SaleItems, cancellationToken);
        var result = _mapper.Map<CreateSalesItemsResult>(createdSaleItems);
        var createdSaleItemsEvent = new SaleRegister { SaleNumber = command.ProductId, Date = DateTime.UtcNow };
        await _eventPublisher.PublishAsync(createdSaleItemsEvent, cancellationToken);
        return result;
    }
}
