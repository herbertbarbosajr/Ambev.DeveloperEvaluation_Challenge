using Ambev.DeveloperEvaluation.Common.Security;
using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

public class Sale : BaseEntity, ISale
{

    /// <summary>
    /// Gets the sale's full name.
    /// Must not be null or empty.
    /// </summary>
    public int SaleNumber { get; set; }

    /// <summary>
    /// Gets the sale's date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Get the sale's customer.
    /// </summary>
    public string Customer { get; set; }

    /// <summary>
    /// Gets the TotalAmount when the sale was created.
    /// </summary>
    public decimal TotalAmount { get; set; }

    /// <summary>
    /// Gets the Branch sale's information.
    /// </summary>
    public string Branch { get; set; }

    /// <summary>
    /// Get List of items
    /// </summary>
    public List<SaleItem> Items { get; set; }

    /// <summary>
    /// Identify is cancel
    /// </summary>
    public bool IsCancelled { get; set; }

    /// <summary>
    /// Gets the unique identifier of the sale.
    /// </summary>
    /// <returns>The sale's ID as a string.</returns>
    string ISale.Id => Id.ToString();


    /// <summary>
    /// Performs validation of the sale entity using the saleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed
    /// - Errors: Collection of validation errors if any rules failed
    /// </returns>
    /// <remarks>
    /// <listheader>The validation includes checking:</listheader>
    /// <list type="bullet">saleName format and length</list>
    /// <list type="bullet">Price format</list>
    /// <list type="bullet">Stocked validity</list>
    /// 
    /// </remarks>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Activates the sale account.
    /// Changes the sale's status to Active.
    /// </summary>
    public void Activate()
    {
        IsCancelled = false;
    }

    /// <summary>
    /// Desactivates the sale account.
    /// Changes the sale's status to Inactive.
    /// </summary>
    public void Deactivate()
    {
        IsCancelled = true;
    }

}
