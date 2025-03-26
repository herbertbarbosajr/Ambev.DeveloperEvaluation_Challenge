using Ambev.DeveloperEvaluation.Domain.Entities.Registers;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Domain.Entities.TestRegisters;


public class CancelSaleRegisterTests
{
    [Fact]
    public void CancelSaleRegister_ShouldSetPropertiesCorrectly()
    {
        // Arrange
        var saleNumber = Guid.NewGuid();
        var cancelDate = DateTime.UtcNow;

        // Act
        var cancelSaleRegister = new CancelSaleRegister
        {
            SaleNumber = saleNumber,
            CancelDate = cancelDate
        };

        // Assert
        cancelSaleRegister.SaleNumber.Should().Be(saleNumber);
        cancelSaleRegister.CancelDate.Should().Be(cancelDate);
    }

    [Fact]
    public void CancelSaleRegister_ShouldHaveDefaultValues()
    {
        // Act
        var cancelSaleRegister = new CancelSaleRegister();

        // Assert
        cancelSaleRegister.SaleNumber.Should().Be(Guid.Empty);
        cancelSaleRegister.CancelDate.Should().Be(default);
    }
}
