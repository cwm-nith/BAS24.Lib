using Microsoft.Extensions.DependencyInjection;
namespace BAS24.Libs.CQRS.Commands;

public sealed class CommandDispatcher:ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public CommandDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public Task PerformAsync<T, TId>(T command, TId id) where T : class, ICommand
    {
        var handler = _serviceProvider.GetService<ICommandHandler<T, TId>>();

        if (handler is null)
        {
            throw new InvalidOperationException($"Command handler for: '{command}' was not found.");
        }

        return handler.HandleAsync(command, id);
    }

    Task ICommandDispatcher.PerformAsync<T>(T command)
    {
        var handler = _serviceProvider.GetService<ICommandHandler<T>>();

        if (handler is null)
        {
            throw new InvalidOperationException($"Command handler for: '{command}' was not found.");
        }

        return handler.HandleAsync(command);
    }
}