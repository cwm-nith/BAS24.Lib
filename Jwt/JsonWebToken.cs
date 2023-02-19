namespace BAS24.Libs.Jwt;

public class JsonWebToken
{
    public string AccessToken { get; set; } = string.Empty;
    public string RefreshToken { get; set; } = string.Empty;
}