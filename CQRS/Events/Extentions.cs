using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.CQRS.Events;

public static class Extentions
{
    public static IServiceCollection AddEventHandlers(this IServiceCollection services)
    {
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IEventHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }
}