using Ambev.DeveloperEvaluation.Domain.Entities.Registers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestRegisters
{
   

    public class CancelItemTests
    {
        [Fact]
        public void CancelItem_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            var saleId = Guid.NewGuid();
            var cancelDate = DateTime.UtcNow;

            // Act
            var cancelItem = new CancelItem
            {
                SaleId = saleId,
                CancelDate = cancelDate
            };

            // Assert
            cancelItem.SaleId.Should().Be(saleId);
            cancelItem.CancelDate.Should().Be(cancelDate);
        }

        [Fact]
        public void CancelItem_ShouldHaveDefaultValues()
        {
            // Act
            var cancelItem = new CancelItem();

            // Assert
            cancelItem.SaleId.Should().Be(Guid.Empty);
            cancelItem.CancelDate.Should().Be(default);
        }
    }



}
