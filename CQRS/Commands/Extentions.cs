using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.CQRS.Commands;

public static class Extentions
{
    public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
    {
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());
        
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<,>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }
}