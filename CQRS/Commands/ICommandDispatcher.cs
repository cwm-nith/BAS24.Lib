namespace BAS24.Libs.CQRS.Commands;

public interface ICommandDispatcher
{
    Task PerformAsync<T, TId>(T command, TId id) where T : class, ICommand;
    Task PerformAsync<T>(T command) where T : class, ICommand;
}