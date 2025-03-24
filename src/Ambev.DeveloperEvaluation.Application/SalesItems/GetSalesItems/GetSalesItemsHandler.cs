using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;

/// <summary>
/// Handler for processing GetSaleItemsCommand requests
/// </summary>
public class GetSalesItemsHandler : IRequestHandler<GetSalesItemsCommand, GetSalesItemsResult>
{
    private readonly ISaleItemRepository _SaleItemsRepository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetSaleItemsHandler
    /// </summary>
    /// <param name="SaleItemsRepository">The SaleItems repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    /// <param name="validator">The validator for GetSaleItemsCommand</param>
    public GetSalesItemsHandler(
        ISaleItemRepository SaleItemsRepository,
        IMapper mapper)
    {
        _SaleItemsRepository = SaleItemsRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetSaleItemsCommand request
    /// </summary>
    /// <param name="request">The GetSaleItems command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The SaleItems details if found</returns>
    public async Task<GetSalesItemsResult> Handle(GetSalesItemsCommand request, CancellationToken cancellationToken)
    {
        var validator = new GetSaleItemsValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var SaleItems = await _SaleItemsRepository.GetByIdAsync(request.Id, cancellationToken);
        if (SaleItems == null)
            throw new KeyNotFoundException($"SaleItems with ID {request.Id} not found");

        return _mapper.Map<GetSalesItemsResult>(SaleItems);
    }
}
