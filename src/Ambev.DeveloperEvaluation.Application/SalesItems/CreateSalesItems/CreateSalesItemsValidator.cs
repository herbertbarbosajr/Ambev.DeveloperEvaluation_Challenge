using Ambev.DeveloperEvaluation.Domain.Validation;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;

/// <summary>
/// Validator for CreateSaleItemsCommand that defines validation rules for SaleItems creation command.
/// </summary>
public class CreateSaleItemsCommandValidator : AbstractValidator<CreateSalesItemsCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleItemsCommandValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - Email: Must be in valid format (using EmailValidator)
    /// - SaleItemsname: Required, must be between 3 and 50 characters
    /// - Password: Must meet security requirements (using PasswordValidator)
    /// - Phone: Must match international format (+X XXXXXXXXXX)
    /// - Status: Cannot be set to Unknown
    /// - Role: Cannot be set to None
    /// </remarks>
    public CreateSaleItemsCommandValidator()
    {
       
        RuleFor(SaleItems => SaleItems.UnitPrice).NotEmpty();
        RuleFor(SaleItems => SaleItems.Quantity).NotEmpty();
       
    }
}