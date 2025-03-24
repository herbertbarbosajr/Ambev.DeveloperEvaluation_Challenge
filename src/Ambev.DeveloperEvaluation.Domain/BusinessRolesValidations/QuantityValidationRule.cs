using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;

public class QuantityValidationRule : IBusinessRules
{
    public void Apply(SaleItem item)
    {
        if (item.Quantity > 20)
        {
            string message = $"Não é possível vender acima de 20 itens idênticos. Quantidade solicitada: {item.Quantity}. Por favor, ajuste a quantidade dos itens e tente novamente.";
            throw new InvalidOperationException(message);
        }
    }
}
