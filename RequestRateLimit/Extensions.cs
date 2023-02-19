using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.RequestRateLimit;

public static class Extensions
{
    public static IServiceCollection AddRequestRateLimit(this IServiceCollection services)
    {
        // needed to load configuration from appsettings.json
        services.AddOptions();

        // needed to store rate limit counters and ip rules
        services.AddMemoryCache();

        var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
        services.Configure<IpRateLimitOptions>(configuration!.GetSection("IpRateLimiting"));

        //load ip rules from appsettings.json
        services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

        // inject counter and rules stores
        services.AddSingleton<IIpPolicyStore, MemoryCacheIpPolicyStore>();
        services.AddSingleton<IRateLimitCounterStore, MemoryCacheRateLimitCounterStore>();

        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

        services.AddSingleton<IClientPolicyStore, DistributedCacheClientPolicyStore>();
        services.AddSingleton<IRateLimitCounterStore, DistributedCacheRateLimitCounterStore>();
        return services;
    }
}