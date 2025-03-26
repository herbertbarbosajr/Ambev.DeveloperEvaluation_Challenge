using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Specifications;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Specifications
{
    public class ActiveSaleSpecificationTests
    {
        [Fact]
        public void IsSatisfiedBy_ShouldReturnTrue_WhenSaleIsNotCancelled()
        {
            // Arrange
            var sale = new Sale
            {
                IsCancelled = false
            };
            var specification = new ActiveSaleSpecification();

            // Act
            var result = specification.IsSatisfiedBy(sale);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public void IsSatisfiedBy_ShouldReturnFalse_WhenSaleIsCancelled()
        {
            // Arrange
            var sale = new Sale
            {
                IsCancelled = true
            };
            var specification = new ActiveSaleSpecification();

            // Act
            var result = specification.IsSatisfiedBy(sale);

            // Assert
            result.Should().BeFalse();
        }
    }
}
