using Xunit;
using Moq;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using FluentAssertions;
using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.Unit.WebApi;
public class SalesControllerTests
{
    private readonly Mock<IMediator> _mediatorMock;
    private readonly Mock<IMapper> _mapperMock;
    private readonly SalesController _controller;

    public SalesControllerTests()
    {
        _mediatorMock = new Mock<IMediator>();
        _mapperMock = new Mock<IMapper>();
        _controller = new SalesController(_mediatorMock.Object, _mapperMock.Object);
    }

    [Fact]
    public async Task CreateSale_ShouldReturnCreatedResult_WhenRequestIsValid()
    {
        // Arrange
        var request = new CreateSaleRequest { SaleNumber = 1, Date = DateTime.Now, Customer = "Customer", TotalAmount = 100, Branch = "Branch", Items = new List<SaleItem>(), IsCancelled = false };
        var command = new CreateSaleCommand();
        var result = new CreateSaleResult { Id = Guid.NewGuid() };

        _mapperMock.Setup(m => m.Map<CreateSaleCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>())).ReturnsAsync(result);
        _mapperMock.Setup(m => m.Map<CreateSaleResponse>(result)).Returns(new CreateSaleResponse { Id = result.Id });

        // Act
        var response = await _controller.CreateSale(request, CancellationToken.None);

        // Assert
        var createdResult = response as CreatedResult;
        createdResult.Should().NotBeNull();
        createdResult.StatusCode.Should().Be(201);
        var apiResponse = createdResult.Value as ApiResponseWithData<CreateSaleResponse>;
        apiResponse.Should().NotBeNull();
        apiResponse.Data.Id.Should().Be(result.Id);
    }

    [Fact]
    public async Task UpdateSale_ShouldReturnOkResult_WhenRequestIsValid()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new UpdateSaleRequest { Id = id, SaleNumber = 1, Date = DateTime.Now, Customer = "Customer", TotalAmount = 100, Branch = "Branch", Items = new List<SaleItem>(), IsCancelled = false };
        var command = new UpdateSaleCommand
        {
            Id = request.Id,
            SaleNumber = request.SaleNumber,
            Date = request.Date,
            Customer = request.Customer,
            TotalAmount = request.TotalAmount,
            Branch = request.Branch,
            Items = request.Items,
            IsCancelled = request.IsCancelled
        };
        var result = new UpdateSaleResult { Id = id };

        _mapperMock.Setup(m => m.Map<UpdateSaleCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>())).ReturnsAsync(result);
        _mapperMock.Setup(m => m.Map<UpdateSaleResponse>(result)).Returns(new UpdateSaleResponse { Id = result.Id });

        // Act
        var response = await _controller.UpdateSale(id, request, CancellationToken.None);

        // Assert
        var okResult = response as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult.StatusCode.Should().Be(200);
        var apiResponse = okResult.Value;
        apiResponse.Should().NotBeNull();
    }

    [Fact]
    public async Task GetSale_ShouldReturnOkResult_WhenSaleExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new GetSaleRequest { Id = id };
        var command = new GetSaleCommand(id); // Pass the id as a constructor parameter
        var result = new GetSaleResult { Id = id };

        _mapperMock.Setup(m => m.Map<GetSaleCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>())).ReturnsAsync(result);
        _mapperMock.Setup(m => m.Map<GetSaleResponse>(result)).Returns(new GetSaleResponse { Id = result.Id });

        // Act
        var response = await _controller.GetSale(id, CancellationToken.None);

        // Assert
        var okResult = response as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult.StatusCode.Should().Be(200);  
        response.Should().NotBeNull();
       
    }

    [Fact]
    public async Task DeleteSale_ShouldReturnOkResult_WhenSaleExists()
    {
        // Arrange
        var id = Guid.NewGuid();
        var request = new DeleteSaleRequest { Id = id };
        var command = new DeleteSaleCommand(id);

        _mapperMock.Setup(m => m.Map<DeleteSaleCommand>(request)).Returns(command);
        _mediatorMock.Setup(m => m.Send(command, It.IsAny<CancellationToken>())).ReturnsAsync(new DeleteSaleResponse { Success = true });

        // Act
        var response = await _controller.DeleteSale(id, CancellationToken.None);

        // Assert
        var okResult = response as OkObjectResult;
        okResult.Should().NotBeNull();
        okResult.StatusCode.Should().Be(200);
        var apiResponse = okResult.Value as ApiResponse;
        apiResponse.Should().NotBeNull();
        apiResponse.Success.Should().BeTrue();
    }
}
