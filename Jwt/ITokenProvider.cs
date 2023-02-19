using System.Security.Claims;

namespace BAS24.Libs.Jwt;

public interface ITokenProvider<in TUser> where TUser : class
{
    string CreateToken(TUser user, string userId);
    string CreateToken(string id, string code);
    string CreateToken(Claim[] claims);
    bool ValidateToken(string token);
}