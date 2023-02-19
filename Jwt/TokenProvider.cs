using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace BAS24.Libs.Jwt;

public class TokenProvider<TUser> : ITokenProvider<TUser> where TUser : class
{
    private readonly IServiceProvider _serviceProvider;

    public TokenProvider(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
    public string CreateToken(TUser user, string userId)
        => CreateToken(new Claim[] {
                    new Claim(ClaimTypes.Name, userId) });

    public string CreateToken(string id, string code)
        => CreateToken(new Claim[] {
                    new Claim(ClaimTypes.Name, id),
                    new Claim("Code", code) });

    public string CreateToken(Claim[] claims)
    {
        var option = _serviceProvider.GetService<JwtOptions>();

        var key = Encoding.UTF8.GetBytes(option!.SigningKey);

        var expiryInMinutes = option.ExpiryInMinutes;

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(expiryInMinutes),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = option.Site,
            Audience = option.Site,

        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = GetValidationParameters();

        IPrincipal principal = tokenHandler.ValidateToken(token, validationParameters, out _);

        return true;
    }

    private TokenValidationParameters GetValidationParameters()
    {
        var option = _serviceProvider.GetService<JwtOptions>();

        return new TokenValidationParameters()
        {
            ValidateLifetime = false, // Because there is no expiration in the generated token
            ValidateAudience = true, // Because there is no audiance in the generated token
            ValidateIssuer = true,   // Because there is no issuer in the generated token
            ValidIssuer = option?.Site,
            ValidAudience = option?.Site,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(option!.SigningKey)) // The same key as the one that generate the token
        };
    }
}
