
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Devhunt_2024_back.Services;

#nullable disable
public class JwtService
{
    private readonly string _secureKey;

    public JwtService(IConfiguration configuration)
    {
        _secureKey = configuration["Jwt:SecureKey"];
    }
    //GENERATE TOKEN
    public string Generator(string uid, string role)
    {
        // Security data
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);
        var jwtHeader = new JwtHeader(credentials);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, uid),
            new Claim(ClaimTypes.Role, role)
            // Add role claim here
        };

        var jwtPayload = new JwtPayload(uid, null, claims, null, DateTime.Now.AddDays(7));
        var securityToken = new JwtSecurityToken(jwtHeader, jwtPayload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    //CHECK TOKEN VALIDATION
    public JwtSecurityToken Checker(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secureKey);
        tokenHandler.ValidateToken(
            jwt,
            new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
            },
            out SecurityToken validateToken
        );
        return (JwtSecurityToken)validateToken;
    }
}
