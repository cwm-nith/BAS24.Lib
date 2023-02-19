namespace BAS24.Libs.CQRS.Queries;

public interface IQueryDispatcher
{
    Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : class, IQuery<TResult>;
}