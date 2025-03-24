using Ambev.DeveloperEvaluation.Domain.Entities.Registers;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Ambev.DeveloperEvaluation.Unit.Application.TestData
{
   
    public class LogEventPublisherTests
    {
        private readonly Mock<ILogger<LogEventPublisher>> _loggerMock;
        private readonly LogEventPublisher _eventPublisher;

        public LogEventPublisherTests()
        {
            _loggerMock = new Mock<ILogger<LogEventPublisher>>();
            _eventPublisher = new LogEventPublisher(_loggerMock.Object);
        }

        [Fact]
        public async Task PublishAsync_ShouldLogEvent_WhenCalled()
        {
            // Arrange
            var @event = new SaleRegister { SaleNumber = 123, Date = DateTime.UtcNow };

            // Act
            await _eventPublisher.PublishAsync(@event, CancellationToken.None);

            // Assert
            _loggerMock.Verify(
                x => x.Log(
                    LogLevel.Information,
                    It.IsAny<EventId>(),
                    It.Is<It.IsAnyType>((v, t) => v.ToString().Contains("Evento publicado")),
                    null,
                    It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
        }
    }

}
