namespace BAS24.Libs.CQRS.Events;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    Task HandleAsync(TEvent e);
}