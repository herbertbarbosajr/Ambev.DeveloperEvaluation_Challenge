using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;

/// <summary>
/// Handler for processing CreateSaleItemsCommand requests
/// </summary>
public class CreateSalesItemsHandler : IRequestHandler<CreateSalesItemsCommand, CreateSalesItemsResult>
{
    private readonly ISaleItemRepository _SaleItemsRepository;
    private readonly IMapper _mapper;
    

    /// <summary>
    /// Initializes a new instance of CreateSaleItemsHandler
    /// </summary>
    /// <param name="SaleItemsRepository">The SaleItems repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for CreateSaleItemsCommand</param>
    public CreateSalesItemsHandler(ISaleItemRepository SaleItemsRepository, 
        IMapper mapper)
    {
        _SaleItemsRepository = SaleItemsRepository;
        _mapper = mapper;
       
    }

    /// <summary>
    /// Handles the CreateSaleItemsCommand request
    /// </summary>
    /// <param name="command">The CreateSaleItems command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SaleItems details</returns>
    public async Task<CreateSalesItemsResult> Handle(CreateSalesItemsCommand command, CancellationToken cancellationToken)
    {
        var validator = new CreateSaleItemsCommandValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var SaleItems = _mapper.Map<SaleItem>(command);
        
        var createdSaleItems = await _SaleItemsRepository.CreateAsync(SaleItems, cancellationToken);
        var result = _mapper.Map<CreateSalesItemsResult>(createdSaleItems);
        return result;
    }
}
