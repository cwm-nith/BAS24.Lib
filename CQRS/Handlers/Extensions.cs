using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.CQRS.Handlers;

public static class Extensions
{
    public static IServiceCollection AddCommandCorrelationContextHandlers(this IServiceCollection services)
    {
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(ICommandCorrelationContextHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }
    public static IServiceCollection AddEventCorrelationContextHandlers(this IServiceCollection services)
    {
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IEventCorrelationContextHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }
}