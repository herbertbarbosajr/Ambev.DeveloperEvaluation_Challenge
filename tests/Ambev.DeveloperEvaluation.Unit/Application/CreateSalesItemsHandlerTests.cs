using Xunit;
using Moq;
using AutoMapper;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.EventsPublishers;
using Ambev.DeveloperEvaluation.Domain.Entities.Registers;

namespace Ambev.DeveloperEvaluation.Unit.Application.SaleItems.CreateSalesItems;

public class CreateSalesItemsHandlerTests
{
    private readonly Mock<ISaleItemRepository> _saleItemRepositoryMock;
    private readonly Mock<IEventPublisher> _eventPublisherMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly Mock<IValidator<CreateSalesItemsCommand>> _validatorMock;
    private readonly CreateSalesItemsHandler _handler;
  

    public CreateSalesItemsHandlerTests()
    {
        _saleItemRepositoryMock = new Mock<ISaleItemRepository>();
        _eventPublisherMock = new Mock<IEventPublisher>();
        _mapperMock = new Mock<IMapper>();
        _validatorMock = new Mock<IValidator<CreateSalesItemsCommand>>();
        _handler = new CreateSalesItemsHandler(
            _saleItemRepositoryMock.Object,
            _mapperMock.Object,
            _eventPublisherMock.Object,
           _validatorMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldValidateCommand()
    {
        // Arrange
        var command = new CreateSalesItemsCommand {ProductId = 123, UnitPrice = 102, Discount = 10, Quantity = 3, TotalAmount = 370 };
        var validationResult = new ValidationResult();
        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _validatorMock.Verify(v => v.ValidateAsync(command, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldCreateSaleItem_WhenCommandIsValid()
    {
        // Arrange
        var command = new CreateSalesItemsCommand { ProductId = 123, UnitPrice = 102, Discount = 10, Quantity = 3, TotalAmount = 370 };
        var validationResult = new ValidationResult();
        var saleItem = new SaleItem();
        var createdSaleItem = new SaleItem();
        var result = new CreateSalesItemsResult { Id = Guid.NewGuid() };

        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);
        _mapperMock.Setup(m => m.Map<SaleItem>(command)).Returns(saleItem);
        _saleItemRepositoryMock.Setup(r => r.CreateAsync(saleItem, It.IsAny<CancellationToken>())).ReturnsAsync(createdSaleItem);
        _mapperMock.Setup(m => m.Map<CreateSalesItemsResult>(createdSaleItem)).Returns(result);

        // Act
        var response = await _handler.Handle(command, CancellationToken.None);

        // Assert
        response.Should().Be(result);
        _saleItemRepositoryMock.Verify(r => r.CreateAsync(saleItem, It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldPublishEvent_WhenSaleItemIsCreated()
    {
        // Arrange
        var command = new CreateSalesItemsCommand { ProductId = 123, UnitPrice = 102,  Discount = 10 , Quantity = 3, TotalAmount = 370};
        var validationResult = new ValidationResult();
        var saleItem = new SaleItem();
        var createdSaleItem = new SaleItem();
        var result = new CreateSalesItemsResult { Id = Guid.NewGuid() };

        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);
        _mapperMock.Setup(m => m.Map<SaleItem>(command)).Returns(saleItem);
        _saleItemRepositoryMock.Setup(r => r.CreateAsync(saleItem, It.IsAny<CancellationToken>())).ReturnsAsync(createdSaleItem);
        _mapperMock.Setup(m => m.Map<CreateSalesItemsResult>(createdSaleItem)).Returns(result);

        // Act
        await _handler.Handle(command, CancellationToken.None);

        // Assert
        _eventPublisherMock.Verify(e => e.PublishAsync(It.IsAny<SaleRegister>(), It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public void Handle_ShouldThrowValidationException_WhenCommandIsInvalid()
    {
        // Arrange
        var command = new CreateSalesItemsCommand {ProductId = 123, UnitPrice = 102, Discount = 10, Quantity = 3, TotalAmount = 370 };
        var validationResult = new ValidationResult(new[] { new ValidationFailure("ProductId", "Invalid") });

        _validatorMock.Setup(v => v.ValidateAsync(command, It.IsAny<CancellationToken>())).ReturnsAsync(validationResult);

        // Act
        Func<Task> act = async () => await _handler.Handle(command, CancellationToken.None);

        // Assert
        act.Should().ThrowAsync<ValidationException>();
        _saleItemRepositoryMock.Verify(r => r.CreateAsync(It.IsAny<SaleItem>(), It.IsAny<CancellationToken>()), Times.Never);
    }
}





