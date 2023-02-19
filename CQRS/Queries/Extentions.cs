using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.CQRS.Queries;

public static class Extentions
{
    public static IServiceCollection AddQueryHandlers(this IServiceCollection services)
    {
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IQueryHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }
}