namespace BAS24.Libs.Localization;

public interface ILocalization
{
    Task<string> GetStringAsync(string key, string region = "");
}