using Ambev.DeveloperEvaluation.Application.EventsPublishers;
using Microsoft.Extensions.Logging;

public class LogEventPublisher : IEventPublisher
{
    private readonly ILogger<LogEventPublisher> _logger;

    public LogEventPublisher(ILogger<LogEventPublisher> logger)
    {
        _logger = logger;
    }

    public Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : class
    {
        _logger.LogInformation("Evento publicado: {Event}", @event);
        return Task.CompletedTask;
    }
}
