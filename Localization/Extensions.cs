using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.Localization;

public static class Extensions
{
    public static IServiceCollection AddLocalize(this IServiceCollection services, string path)
    {
        services.AddSingleton(new LocalizationOptions { Path = path });
        services.AddTransient<ILocalization, Localization>();
        return services;
    }
}