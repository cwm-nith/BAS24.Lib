using BAS24.Libs.Exceptions;

namespace BAS24.Libs.CQRS.Messages;

public interface IHandler
{
    IHandler Handle(Func<Task> handle);
    IHandler OnSuccess(Func<Task> onSuccess);
    IHandler OnError(Func<Exception, Task> onError, bool rethrow = false);
    IHandler OnCustomError(Func<BaseException, Task> onCustomError, bool rethrow = false);
    IHandler Always(Func<Task> always);
    Task ExecuteAsync();
}