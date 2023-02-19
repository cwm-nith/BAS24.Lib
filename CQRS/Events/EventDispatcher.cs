namespace BAS24.Libs.CQRS.Events;
using Microsoft.Extensions.DependencyInjection;

public sealed class EventDispatcher:IEventDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public EventDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public Task PublishAsync<T>(T @event) where T : class, IEvent
    {
        var handler = _serviceProvider.GetService<IEventHandler<T>>();

        if (handler is null)
        {
            throw new InvalidOperationException($"Event handler for: '{@event}' was not found.");
        }

        return handler.HandleAsync(@event);
    }
}