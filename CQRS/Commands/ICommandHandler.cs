namespace BAS24.Libs.CQRS.Commands;

public interface ICommandHandler<in TCommand, in TId> where TCommand : class, ICommand
{
    Task HandleAsync(TCommand command, TId id);
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task HandleAsync(TCommand command);
}