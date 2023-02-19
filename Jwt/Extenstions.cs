using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.Jwt;

public static class Extenstions
{
    private const string SectionName = "jwt";
    public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var option = services.Configure<JwtOptions>(options => configuration.GetSection(SectionName)
            .Bind(options));
        services.AddSingleton(option);

        return services;
    }
}