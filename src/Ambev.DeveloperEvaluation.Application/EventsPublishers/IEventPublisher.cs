namespace Ambev.DeveloperEvaluation.Application.EventsPublishers;

public interface IEventPublisher
{
    Task PublishAsync<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : class;
}
