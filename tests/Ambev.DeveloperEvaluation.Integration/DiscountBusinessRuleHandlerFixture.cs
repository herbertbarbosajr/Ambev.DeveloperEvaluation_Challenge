using Ambev.DeveloperEvaluation.Domain.BusinessRolesValidations;

namespace Ambev.DeveloperEvaluation.Integration
{
    public class DiscountBusinessRuleHandlerFixture
    {
        public DiscountBusinessRuleHandler DiscountBusinessRuleHandler { get; }

        public DiscountBusinessRuleHandlerFixture()
        {
            // Inicialize o DiscountBusinessRuleHandler aqui
            DiscountBusinessRuleHandler = new DiscountBusinessRuleHandler(new List<IBusinessRules>());
        }
    }

}


