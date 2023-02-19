namespace BAS24.Libs.CQRS.Queries;

public class PagedQuery : IPagedQuery
{
    public int Page { get; set; }
    public int Results { get; set; }
}