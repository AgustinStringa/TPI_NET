using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Model;
using Microsoft.Extensions.Configuration;

namespace API.Helpers
{
    public class AuthHelpers
    {
        public AuthHelpers() { }
        public static string GenerateJWTToken(User user)
        {
            var jwtSecret = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("MySettings")["JWT_Secret"];

            var claims = new List<Claim> {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.Name),
    };
            var jwtToken = new JwtSecurityToken(
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(30),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(jwtSecret)
                        ),
                    SecurityAlgorithms.HmacSha256Signature)
                ); ;
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
