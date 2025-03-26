using Ambev.DeveloperEvaluation.Application.SaleItems.CreateSalesItems;
using Bogus;

namespace Ambev.DeveloperEvaluation.Unit.Domain;

/// <summary>
/// Provides methods for generating test data using the Bogus library.
/// This class centralizes all test data generation to ensure consistency
/// across test cases and provide both valid and invalid data scenarios.
/// </summary>
public static class CreateSaleItemHandlerTestData
{
    /// <summary>
    /// Configures the Faker to generate valid CreateSalesItemsCommand entities.
    /// </summary>
    private static readonly Faker<CreateSalesItemsCommand> createSalesItemsHandlerFaker = new Faker<CreateSalesItemsCommand>()
        .RuleFor(c => c.ProductId, f => f.Random.Int(1, 1000))
        .RuleFor(c => c.Quantity, f => f.Random.Int(1, 100))
        .RuleFor(c => c.UnitPrice, f => f.Finance.Amount(1, 1000))
        .RuleFor(c => c.Discount, f => f.Finance.Amount(0, 100))
        .RuleFor(c => c.TotalAmount, (f, c) => c.Quantity * c.UnitPrice - c.Discount);

    /// <summary>
    /// Generates a valid CreateSalesItemsCommand entity with randomized data.
    /// </summary>
    /// <returns>A valid CreateSalesItemsCommand entity with randomly generated data.</returns>
    public static CreateSalesItemsCommand GenerateValidCommand()
    {
        return createSalesItemsHandlerFaker.Generate();
    }
}
