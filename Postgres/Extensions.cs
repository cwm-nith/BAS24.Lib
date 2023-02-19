using BAS24.Libs.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.Postgres;

public static class Extensions
{
    public static IServiceCollection AddPostgres<TContext>(this IServiceCollection services) where TContext : DbContext
    {
        var postgresOption = services.GetOptions<PostgresOption>("Postgres");
        services.AddSingleton(postgresOption);
        //services.AddEntityFrameworkNpgsql();
        services.AddDbContext<TContext>(option =>
            option.UseNpgsql(postgresOption.ConnectionStrings, opt => opt
                        .EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null)
                        .CommandTimeout((int)TimeSpan.FromMinutes(5).TotalSeconds))
                  .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                  .EnableSensitiveDataLogging(false)
        );

        services.AddTransient<IPostgresInitializer, PostgresInitializer>();
        services.AddTransient<IPostgresSeeder, PostgresDefaultSeeder>();

        return services;
    }

    public static Guid ToGuid(this string? id)
    {
        var re = Guid.TryParse(id, out var guid);
        if (!re)
            throw new InvalidGuidException(id ?? "empty");
        return guid;
    }
    public static Guid? ToGuidNullable(this string? id)
    {
        if (id == null) return null;
        var re = Guid.TryParse(id, out var guid);
        if (!re)
            return null;
        return guid;
    }
    public static IEnumerable<TResult> FullJoinDistinct<TLeft, TRight, TKey, TResult>(
    this IEnumerable<TLeft> leftItems,
    IEnumerable<TRight> rightItems,
    Func<TLeft, TKey> leftKeySelector,
    Func<TRight, TKey> rightKeySelector,
    Func<TLeft, TRight, TResult> resultSelector
)
    {

        var leftJoin =
            from left in leftItems
            join right in rightItems
              on leftKeySelector(left) equals rightKeySelector(right) into temp
            from right in temp.DefaultIfEmpty()
            select resultSelector(left, right);

        var rightJoin =
            from right in rightItems
            join left in leftItems
              on rightKeySelector(right) equals leftKeySelector(left) into temp
            from left in temp.DefaultIfEmpty()
            select resultSelector(left, right);

        return leftJoin.Union(rightJoin);
    }
}
