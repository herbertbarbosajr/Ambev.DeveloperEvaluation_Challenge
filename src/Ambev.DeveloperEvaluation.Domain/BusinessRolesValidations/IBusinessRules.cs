using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;

public interface IBusinessRules
{
    void Apply(SaleItem item);
}
