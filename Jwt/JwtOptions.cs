namespace BAS24.Libs.Jwt;

public class JwtOptions
{
    public string Site { get; set; } = string.Empty;
    public string SigningKey { get; set; } = string.Empty;
    public int ExpiryInMinutes { get; set; }
}