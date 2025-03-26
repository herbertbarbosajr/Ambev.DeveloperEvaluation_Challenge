using Xunit;
using Moq;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;
using Ambev.DeveloperEvaluation.Application.EventsPublishers;
using Ambev.DeveloperEvaluation.Domain.Entities.Registers;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.Unit.Domain;

namespace Ambev.DeveloperEvaluation.Unit.Application;
public class CreateSaleHandlerTests
{
    private readonly Mock<ISaleRepository> _saleRepositoryMock;
    private readonly Mock<IEventPublisher> _eventPublisherMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<DiscountBusinessRuleHandler> _discountBusinessRuleHandlerMock;
    private readonly Mock<ILogger<CreateSaleHandler>> _loggerMock;
    private readonly Mock<IValidator<CreateSaleCommand>> _validatorMock;
    private readonly CreateSaleHandler _handler;

    public CreateSaleHandlerTests()
    {
        _saleRepositoryMock = new Mock<ISaleRepository>();
        _eventPublisherMock = new Mock<IEventPublisher>();
        _mapperMock = new Mock<IMapper>();
        _discountBusinessRuleHandlerMock = new Mock<DiscountBusinessRuleHandler>(new List<IBusinessRules>());
        _loggerMock = new Mock<ILogger<CreateSaleHandler>>();
        _validatorMock = new Mock<IValidator<CreateSaleCommand>>();
        _handler = new CreateSaleHandler(
            _saleRepositoryMock.Object,
            _mapperMock.Object,
            _discountBusinessRuleHandlerMock.Object,
            _loggerMock.Object,
            _validatorMock.Object,
            _eventPublisherMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateSale_WhenCommandIsValid()
    {
        // Arrange
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var validationResult = new ValidationResult();
        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _validatorMock.Verify(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
    {
        // Arrange
        var command = CreateSaleHandlerTestData.GenerateValidCommand();
        var validationResult = new ValidationResult(new[] { new ValidationFailure("SaleNumber", "Invalid") });

        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        await act.Should().ThrowAsync<ValidationException>();
        _saleRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<Sale>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}
