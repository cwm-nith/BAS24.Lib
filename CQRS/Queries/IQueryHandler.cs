namespace BAS24.Libs.CQRS.Queries;

public interface IQueryHandler<in TQuery, TResult> where TQuery : class, IQuery<TResult>
{
    Task<TResult>? HandleAsync(TQuery query);
}
