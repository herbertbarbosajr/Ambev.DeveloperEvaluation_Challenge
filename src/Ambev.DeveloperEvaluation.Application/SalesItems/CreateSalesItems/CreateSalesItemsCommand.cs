using Ambev.DeveloperEvaluation.Common.Validation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;

/// <summary>
/// Command for creating a new SaleItems.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a SaleItems, 
/// including SaleItemsname, password, phone number, email, status, and role. 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSalesItemsResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleItemsCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSalesItemsCommand : IRequest<CreateSalesItemsResult>
{
    /// <summary>
    /// Gets or sets the ProductId of the SaleItems to be created.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets Quantity for the SaleItems.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the UnitPrice for the SaleItems.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the Discount for the SaleItems.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets or sets TotalAmount of the SaleItems.
    /// </summary>
    public decimal TotalAmount { get; set; }


    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleItemsCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}