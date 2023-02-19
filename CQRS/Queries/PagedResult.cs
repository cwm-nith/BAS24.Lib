using Newtonsoft.Json;

namespace BAS24.Libs.CQRS.Queries;

public class PagedResult : PagedResultBase
{
    protected PagedResult() { }
    protected PagedResult(
        int currentPage,
        int resultsPerPage,
        int totalPages,
        long totalResults) : base(
        currentPage,
        resultsPerPage,
        totalPages,
        totalResults)
    { }

    public static PagedResult<T> Create<T>(IEnumerable<T> items,
        int currentPage, int resultsPerPage,
        int totalPages, long totalResults)
        => new PagedResult<T>(items, currentPage, resultsPerPage, totalPages, totalResults);

    public static PagedResult<T> From<T>(PagedResultBase result, IEnumerable<T> items)
        => new PagedResult<T>(items, result?.CurrentPage ?? 1, result?.ResultsPerPage ?? 0, result?.TotalPages ?? 0, result?.TotalResults ?? 0);

    public static PagedResult<T> Empty<T>() => new PagedResult<T>();
}
public class PagedResult<T> : PagedResult
{
    public IEnumerable<T> Items { get; set; }

    public bool IsEmpty => !Items.Any();
    public bool IsNotEmpty => !IsEmpty;

    public PagedResult()
    {
        Items = Enumerable.Empty<T>();
    }

    [JsonConstructor]
    public PagedResult(IEnumerable<T> items,
        int currentPage, int resultsPerPage,
        int totalPages, long totalResults) :
        base(currentPage, resultsPerPage, totalPages, totalResults)
    {
        Items = items;
    }



    public PagedResult<TU> Map<TU>(Func<T, TU> map)
        => From(this, Items.Select(map));
}
