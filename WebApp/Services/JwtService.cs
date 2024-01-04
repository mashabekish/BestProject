using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApp.Services
{
    public class JwtService
    {
        public string ValidIssuer { get; }
        public string ValidAudience { get; }
        public SymmetricSecurityKey IssuerSigningKey { get; }

        public JwtService(IConfiguration configuration)
        {
            ValidIssuer = configuration["VALID_ISSUER"] ?? "BestProject";
            ValidAudience = configuration["VALID_AUDIENCE"] ?? "BestGuys";
            var secretKey = Encoding.UTF8.GetBytes(configuration["JWT_SECRET_KEY"] ?? "BestProjectSecretKey!2024");
            IssuerSigningKey = new SymmetricSecurityKey(secretKey);
        }

        public string GetToken(int userId)
        {
            var claims = new Claim[]
            {
                new(ClaimTypes.NameIdentifier, userId.ToString()),
            };
            var jwt = new JwtSecurityToken(
                issuer: ValidIssuer,
                audience: ValidAudience,
            claims: claims,
            expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(IssuerSigningKey, SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
