using System.Globalization;
using System.Resources;
using BAS24.Libs.Localization.Resources;
using Microsoft.Extensions.DependencyInjection;

namespace BAS24.Libs.Localization;

public class Localization : ILocalization
{
    private readonly IServiceProvider _serviceProvider;

    public Localization(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public Task<string> GetStringAsync(string key, string region = "")
        => Task.Run(() =>
        {
            var options = _serviceProvider.GetService<LocalizationOptions>();
            var cultureInfo = new CultureInfo(region);
            var resourceManager = new ResourceManager(options!.Path, typeof(Language).Assembly);
            return resourceManager.GetString(key, cultureInfo) ?? string.Empty;
        });

}
