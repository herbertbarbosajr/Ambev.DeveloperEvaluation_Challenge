using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid CreateSaleCommand entities.
    /// </summary>
    private static readonly Faker<CreateSaleCommand> createSaleHandlerFaker = new Faker<CreateSaleCommand>()
        .RuleFor(c => c.SaleNumber, f => f.Random.Int(1, 1000))
        .RuleFor(c => c.Date, f => f.Date.Past())
        .RuleFor(c => c.Customer, f => f.Person.FullName)
        .RuleFor(c => c.TotalAmount, f => f.Finance.Amount(100, 10000))
        .RuleFor(c => c.Branch, f => f.Company.CompanyName())
        .RuleFor(c => c.Items, f => GenerateSaleItems())
        .RuleFor(c => c.IsCancelled, f => f.Random.Bool());

    /// <summary>
    /// Generates a list of SaleItem entities with randomized data.
    /// </summary>
    /// <returns>A list of SaleItem entities.</returns>
    private static List<SaleItem> GenerateSaleItems()
    {
        var saleItemFaker = new Faker<SaleItem>()
            .RuleFor(i => i.ProductId, f => f.Random.Int(1, 100))
            .RuleFor(i => i.Quantity, f => f.Random.Int(10, 20))
            .RuleFor(i => i.UnitPrice, f => f.Finance.Amount(10, 100))
            .RuleFor(i => i.Discount, f => f.Finance.Amount(10, 20))
            .RuleFor(i => i.TotalAmount, (f, i) => i.Quantity * i.UnitPrice - i.Discount);

        return saleItemFaker.Generate(3); // Gera 3 itens de venda
    }

    /// <summary>
    /// Generates a valid CreateSaleCommand entity with randomized data.
    /// </summary>
    /// <returns>A valid CreateSaleCommand entity with randomly generated data.</returns>
    public static CreateSaleCommand GenerateValidCommand()
    {
        return createSaleHandlerFaker.Generate();
    }
}

