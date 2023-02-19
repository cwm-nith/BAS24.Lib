using Microsoft.Extensions.DependencyInjection;
namespace BAS24.Libs.CQRS.Queries;

public sealed class QueryDispatcher:IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>
    {
        var handler = _serviceProvider.GetService<IQueryHandler<TQuery, TResult>>();

        if (handler is null)
        {
            throw new InvalidOperationException($"Query handler for: '{query}' was not found.");
        }

        return handler.HandleAsync(query)!;
    }
}