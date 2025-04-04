using Xunit;
using Moq;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.UpdateSalesItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSalesItems;
using NSubstitute;

namespace Ambev.DeveloperEvaluation.Unit.WebApi;
public class SalesItemsControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly SalesItemsController _controller;

    public SalesItemsControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _mapperMock = new Mock<IMapper>();
        _controller = new SalesItemsController(_mediatorMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateSale_ShouldReturnCreatedResult_WhenRequestIsValid()
    {
        // Arrange
        var request = new CreateSalesItemsRequest {  Quantity = 10, UnitPrice = 100.0m, Discount = 5.0m, TotalAmount = 950.0m };
        var command = new CreateSalesItemsCommand();
        var result = new CreateSalesItemsResult { Id = Guid.NewGuid() };

        _mapperMock.Setup(m => m.Map<CreateSalesItemsCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>())).ReturnsAsync(result);
        _mapperMock.Setup(m => m.Map<CreateSalesItemsResponse>(result)).Returns(new CreateSalesItemsResponse { Id = result.Id });

        // Act
        var response = await _controller.CreateSalesItems(request, CancellationToken.None);

        // Assert
        var createdResult = response as CreatedResult;
        createdResult.Should().NotBeNull();
        createdResult.StatusCode.Should().Be(201);
        var apiResponse = createdResult.Value as ApiResponseWithData<CreateSalesItemsResponse>;
        apiResponse.Should().NotBeNull();
        apiResponse.Data.Id.Should().Be(result.Id);
    }

    [Fact]
    public async Task UpdateSale_ShouldReturnOkResult_WhenRequestIsValid()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new UpdateSalesItemsRequest
                                        { Id = id, 
                                          ProductId = 1,
                                          Quantity = 10,
                                          UnitPrice = 100.0m,
                                          Discount = 5.0m,
                                          TotalAmount = 950.0m };

        var command = new UpdateSalesItemsCommand
        {
            Id = request.Id,
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            UnitPrice = request.UnitPrice,
            Discount = request.Discount,
            TotalAmount = request.TotalAmount
        };
        var result = new UpdateSalesItemsResult { Id = id };

        _mapperMock.Setup(m => m.Map<UpdateSalesItemsCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>())).ReturnsAsync(result);
        _mapperMock.Setup(m => m.Map<UpdateSalesItemsResponse>(result)).Returns(new UpdateSalesItemsResponse { Id = result.Id });

        // Act
        var response = await _controller.UpdateSalesItems(id, request, CancellationToken.None);

        // Assert
        var okResult = response as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult.StatusCode.Should().Be(200);
        var apiResponse = okResult.Value;
        apiResponse.Should().NotBeNull();
    }
}
