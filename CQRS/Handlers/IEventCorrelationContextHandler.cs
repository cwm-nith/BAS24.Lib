using BAS24.Libs.CQRS.Events;

namespace BAS24.Libs.CQRS.Handlers;

public interface IEventCorrelationContextHandler<in TEvent> where TEvent : IEvent
{
    Task HandleAsync(TEvent @event);
}