using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.Jwt;

public static class Extenstions
{
    private const string SectionName = "jwt";
    public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
    {
        var option = services.GetOptions<JwtOptions>(SectionName);
        services.AddSingleton(option);

        return services;
    }
}