using System.Linq.Expressions;
using BAS24.Libs.CQRS.Queries;
using Microsoft.EntityFrameworkCore;

namespace BAS24.Libs.Postgres;

public static class Pagination
{
    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, IPagedQuery query)
        => await collection.PaginateAsync(query is { Page: var page } ? page : 1, query is { Results: var result } ? result : 0);


    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection,
        int page = 1, int resultsPerPage = 10)
    {
        if (page <= 0)
        {
            page = 1;
        }
        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }
        var isEmpty = await collection.AnyAsync() == false;
        if (isEmpty)
        {
            return PagedResult.Empty<T>();
        }
        var totalResults = await collection.CountAsync();
        var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
        var data = await collection.Limit(page, resultsPerPage).ToListAsync();

        return PagedResult.Create(data, page, resultsPerPage, totalPages, totalResults);
    }
    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, Expression<Func<T, bool>> condition, int resultsPerPage = 10)
    {
        var page = 1;
        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }
        var isEmpty = await collection.AnyAsync() == false;
        if (isEmpty)
        {
            return PagedResult.Empty<T>();
        }
        var totalResults = await collection.CountAsync();
        var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
        var data = await collection.Where(condition).Limit(page, resultsPerPage).ToListAsync();

        return PagedResult.Create(data, page, resultsPerPage, totalPages, totalResults);
    }
    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, IPagedQuery query)
        => collection.Limit(query?.Page ?? 1, query?.Results ?? 0);

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection,
        int page = 1, int resultsPerPage = 10)
    {
        if (page <= 0)
        {
            page = 1;
        }
        if (resultsPerPage <= 0)
        {
            resultsPerPage = 10;
        }
        var skip = (page - 1) * resultsPerPage;

        var data = collection.Skip(skip)
            .Take(resultsPerPage);

        return data;
    }
}
