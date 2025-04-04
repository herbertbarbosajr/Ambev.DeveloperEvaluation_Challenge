using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;
using System.Text.Json.Serialization;

namespace Ambev.DeveloperEvaluation.Domain.Entities;


/// <summary>
/// Represents a Sale in the system with authentication and profile information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class SaleItem : BaseEntity, ISaleItem
{

    /// <summary>
    /// Gets the Sale's id.
    /// Must not be null or empty and should contain both first and last names.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets the Sale's quantity.
    /// Must be quantity.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the Sale's unit price.
    /// Must be a valid unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the Discount.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Determines the Sale's TotalAmount.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets the Sale's FK.
    /// Determines the Sale's.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Gets the unique identifier of the Sale.
    /// </summary>
    /// <returns>The Sale's ID as a string.</returns>
    string ISaleItem.Id => Id.ToString();

    /// <summary>
    /// Performs validation of the Sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">Salename format and length</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }
}