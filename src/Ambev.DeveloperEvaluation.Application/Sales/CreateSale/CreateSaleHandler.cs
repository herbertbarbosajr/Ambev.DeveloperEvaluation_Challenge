using AutoMapper;
using MediatR;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;
using Microsoft.Extensions.Logging;
using FluentValidation.Results;


namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly DiscountBusinessRuleHandler _discountBusinessRuleHandler;
    private readonly ILogger<CreateSaleHandler> _logger;
    private readonly IValidator<CreateSaleCommand> _validator;

    public CreateSaleHandler(
        ISaleRepository saleRepository,
        IMapper mapper,
        DiscountBusinessRuleHandler discountBusinessRule,
        ILogger<CreateSaleHandler> logger,
        IValidator<CreateSaleCommand> validator)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _discountBusinessRuleHandler = discountBusinessRule;
        _logger = logger;
        _validator = validator;
    }

    public async Task<CreateSaleResult> Handle(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        var validationResult = await ValidateCommand(command, cancellationToken);

        if (!validationResult.IsValid)
        {
            HandleValidationErrors(command, validationResult);
        }

        var sale = _mapper.Map<Sale>(command);
        _discountBusinessRuleHandler.Apply(sale);
        var createdSale = await _saleRepository.CreateAsync(sale, cancellationToken);
        var result = _mapper.Map<CreateSaleResult>(createdSale);
        LogSuccess(command);
        return result;
    }

    private async Task<ValidationResult> ValidateCommand(CreateSaleCommand command, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Validating CreateSaleCommand for {SaleId}", command.SaleNumber);
        return await _validator.ValidateAsync(command, cancellationToken);
    }

    private void HandleValidationErrors(CreateSaleCommand command, ValidationResult validationResult)
    {
        _logger.LogWarning("Validation failed for {SaleId}: {Errors}", command.SaleNumber, validationResult.Errors);
        throw new ValidationException(validationResult.Errors);
    }

    private void LogSuccess(CreateSaleCommand command)
    {
        _logger.LogInformation("CreateSaleCommand handled successfully for {SaleId}", command.SaleNumber);
    }
}
