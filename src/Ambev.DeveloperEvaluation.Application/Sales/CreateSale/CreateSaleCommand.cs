using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Entities;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a new Sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for creating a Sale, 
/// including Salename 
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="CreateSaleResult"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="CreateSaleCommandValidator"/> which extends 
/// <see cref="AbstractValidator{T}"/> to ensure that the fields are correctly 
/// populated and follow the required rules.
/// </remarks>
public class CreateSaleCommand : IRequest<CreateSaleResult>
{
    /// <summary>
    /// Gets or sets the SaleNumber of the Sale to be created.
    /// </summary>
    public int SaleNumber { get; set; }

    /// <summary>
    /// Gets or sets the Date for the Sale.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the Customer of the Sale.
    /// </summary>
    public string Customer { get; set; }

    /// <summary>
    /// Gets or sets the TotalAmount of the Sale
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets or sets the Branch of the Sale
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Gets or sets the list of Items of the Sale
    /// </summary>
    public List<SaleItem> Items { get; set; }

    /// <summary>
    ///  <summary>
    /// Gets or sets the Is cancel of the Sale
    /// </summary>
    public bool IsCancelled { get; set; }

    public ValidationResultDetail Validate()
    {
        var validator = new CreateSaleCommandValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}