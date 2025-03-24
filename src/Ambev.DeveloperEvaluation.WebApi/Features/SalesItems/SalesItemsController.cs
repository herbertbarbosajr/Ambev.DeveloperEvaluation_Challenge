using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.GetSalesItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.GetSaleItems;
using Ambev.DeveloperEvaluation.WebApi.Features.SalesItems.DeleteSalesItems;
using Ambev.DeveloperEvaluation.Application.SaleItems.DeleteSaleItems;
using Ambev.DeveloperEvaluation.SaleItems.GetSaleItems;
using Ambev.DeveloperEvaluation.Domain.Extensions;

namespace Ambev.DeveloperEvaluation.WebApi.Features.SalesItems;

/// <summary>
/// Controller for managing SalesItems operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SalesItemsController : BaseController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of SalesItemsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public SalesItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    /// <summary>
    /// Creates a new SalesItems
    /// </summary>
    /// <param name="request">The SalesItems creation request</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The created SalesItems details</returns>
    [HttpPost]
    [ProducesResponseType(typeof(ApiResponseWithData<CreateSalesItemsResponse>), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSalesItems([FromBody] CreateSalesItemsRequest request, CancellationToken cancellationToken)
    {
        var validator = new CreateSalesItemsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<CreateSalesItemsCommand>(request);
        var response = await _mediator.Send(command, cancellationToken);

        return Created(string.Empty, new ApiResponseWithData<CreateSalesItemsResponse>
        {
            Success = true,
            Message = "SalesItems created successfully",
            Data = _mapper.Map<CreateSalesItemsResponse>(response)
        });
    }

    /// <summary>
    /// Retrieves a SalesItems by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the SalesItems</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The SalesItems details if found</returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSalesItemsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSalesItems([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new GetSalesItemsRequest { Id = id };
        var validator = new GetSalesItemsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<GetSalesItemsCommand>(request.Id);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<GetSalesItemsResult>
        {
            Success = true,
            Message = "SalesItems retrieved successfully",
            Data = _mapper.Map<GetSalesItemsResult>(response)
        });
    }

    /// <summary>
    /// Retrieves all SalesItems
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The SalesItems details if found</returns>
    [HttpGet]
    [ProducesResponseType(typeof(ApiResponseWithData<GetSalesItemsResponse>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllSalesItems([FromRoute] CancellationToken cancellationToken, int pageNumer = 1, int pageSize = 10)
    {
        var request = new GetSalesItemsRequestPagination { PageNumber = pageNumer, PageSize = pageSize };
        var validator = new GetSalesItemsRequestPaginationValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = new GetSalesItemsPagination(pageNumer, pageSize);
        var response = await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponseWithData<PaginatedList<GetSalesItemsResult>>
        {
            Success = true,
            Message = "SalesItems retrieved successfully",
            Data = _mapper.Map<PaginatedList<GetSalesItemsResult>>(response)
        });
    }

    /// <summary>
    /// Deletes a SalesItems by their ID
    /// </summary>
    /// <param name="id">The unique identifier of the SalesItems to delete</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Success response if the SalesItems was deleted</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSalesItems([FromRoute] Guid id, CancellationToken cancellationToken)
    {
        var request = new DeleteSalesItemsRequest { Id = id };
        var validator = new DeleteSalesItemsRequestValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
            return BadRequest(validationResult.Errors);

        var command = _mapper.Map<DeleteSalesItemsCommand>(request.Id);
        await _mediator.Send(command, cancellationToken);

        return Ok(new ApiResponse
        {
            Success = true,
            Message = "SalesItems deleted successfully"
        });
    }
}
