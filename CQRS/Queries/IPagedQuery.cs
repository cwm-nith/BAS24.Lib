namespace BAS24.Libs.CQRS.Queries;

public interface IPagedQuery:IQuery
{
    int Page { get; }
    int Results { get; }
}