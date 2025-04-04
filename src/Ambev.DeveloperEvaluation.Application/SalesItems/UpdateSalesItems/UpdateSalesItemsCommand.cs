using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.UpdateSalesItems;

/// <summary>
/// Command for updating an existing SaleItem.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for updating a SaleItem.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="UpdateSalesItemsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="UpdateSalesItemsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class UpdateSalesItemsCommand : IRequest<UpdateSalesItemsResult>
{
    /// <summary>
    /// Gets or sets the unique identifier of the SaleItem to be updated.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the ProductId of the SaleItem to be updated.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets Quantity for the SaleItem.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the UnitPrice for the SaleItem.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the Discount for the SaleItem.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets TotalAmount of the SaleItem.
    /// </summary>
    public decimal TotalAmount { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new UpdateSalesItemsCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}



