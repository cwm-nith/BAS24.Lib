using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.SpecialPassword;

public static class Extensions
{
    public static IServiceCollection AddSpecialPassword(this IServiceCollection services)
    {
        var options = services.GetOptions<SpecialPasswordOptions>("SpecialPasswords");
        services.AddSingleton(options);
        return services;
    }
}