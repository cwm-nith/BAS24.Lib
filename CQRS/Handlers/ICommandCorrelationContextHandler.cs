using BAS24.Libs.CQRS.Commands;

namespace BAS24.Libs.CQRS.Handlers;

public interface ICommandCorrelationContextHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}