namespace BAS24.Libs.Logging;

public class LoggerOptions
{
    public const string Name = "Serilog";
    public string? ApplicationName { get; set; }
    public string? ServiceId { get; set; }
    public ConsoleOptions? Console { get; set; }
    public SeqOptions? Seq { get; set; }
    public IEnumerable<string>? ExcludePaths { get; set; }
}