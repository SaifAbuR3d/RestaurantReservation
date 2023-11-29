using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RestaurantReservation.Db.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationService;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    private readonly IConfiguration _configuration;

    public JwtTokenGenerator(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string? GenerateToken(ApplicationUser user, IList<string> userRoles)
    {

        var authClaims = new List<Claim>
                {
                    new Claim("sub", user.Id),
                    new Claim(ClaimTypes.Name, user.UserName)
                };

        foreach (var userRole in userRoles)
        {
            authClaims.Add(new Claim(ClaimTypes.Role, userRole));
        }

        var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTToken:Key"]));

        var token = new JwtSecurityToken(
            issuer: _configuration["JWTToken:Issuer"],
            audience: _configuration["JWTToken:Audience"],
            expires: DateTime.Now.AddHours(1),
            claims: authClaims,
            signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

        var tokenToReturn = new JwtSecurityTokenHandler()
           .WriteToken(token);

        return tokenToReturn;
    }

}