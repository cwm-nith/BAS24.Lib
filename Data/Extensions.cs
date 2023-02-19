using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.Data;

public static class Extensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.Scan(s =>
            s.FromAssemblies(AppDomain.CurrentDomain.GetAssemblies())
                .AddClasses(c => c.AssignableTo(typeof(IRepository<>)))
                .AsImplementedInterfaces()
                .WithTransientLifetime());

        return services;
    }
}