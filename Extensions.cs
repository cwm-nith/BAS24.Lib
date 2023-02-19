using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs;

public static class Extensions
{
    public static TModel GetOptions<TModel>(this IConfiguration configuration, string section) where TModel : new()
    {
        var model = new TModel();
        configuration?.GetSection(section).Bind(model);

        return model;
    }
    public static string Underscore(this string value)
        => string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString()));
    public static TModel GetOptions<TModel>(this IServiceCollection services, string section) where TModel : new()
    {
        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        return configuration.GetOptions<TModel>(section);
    }

    public static string? Right(this string str, int count)
    {
        if (str.Length < count) return null;
        return str.Substring(str.Length - count, count);
    }
    public static string? Left(this string str, int count)
    {
        return str.Length < count ? null : str[..count];
    }
}