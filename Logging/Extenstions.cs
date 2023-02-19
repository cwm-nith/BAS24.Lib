using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
namespace BAS24.Libs.Logging;

public static class Extenstions
{
    public static IHostBuilder UseLogging(this IHostBuilder host, string? applicationName = null)
        => host.UseSerilog((context, loggerConfiguration) =>
        {
            // var options = context.Configuration.GetOptions<LoggerOptions>("Serilog");
            var options = new LoggerOptions();
            context.Configuration.GetSection(LoggerOptions.Name).Bind(options);
            if (!string.IsNullOrWhiteSpace(options.ApplicationName))
            {
                applicationName = options.ApplicationName;
            }

            loggerConfiguration
                .ReadFrom.Configuration(context.Configuration)
                .Enrich.FromLogContext()
                .Enrich.WithProperty("Environment", context.HostingEnvironment.EnvironmentName)
                .Enrich.WithProperty("ApplicationName", applicationName ?? "");

            Configure(loggerConfiguration, options);
        });

    private static void Configure(LoggerConfiguration loggerConfiguration,
        LoggerOptions options)
    {
        var consoleOptions = options.Console ?? new ConsoleOptions();
        var seqOptions = options.Seq ?? new SeqOptions();
        if (consoleOptions.Enabled)
        {
            loggerConfiguration.WriteTo.Console();
        }

        if (seqOptions.Enabled)
        {
            loggerConfiguration.WriteTo.Seq(seqOptions.Url, apiKey: seqOptions.ApiKey);
        }
    }
}