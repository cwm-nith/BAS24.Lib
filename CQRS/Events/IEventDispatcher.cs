namespace BAS24.Libs.CQRS.Events;

public interface IEventDispatcher
{
    Task PublishAsync<T>(T @event) where T : class, IEvent;
}