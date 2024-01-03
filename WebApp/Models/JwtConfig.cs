using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebApp.Models
{
    public class JwtConfig
    {
        public string ValidIssuer { get; set; }

        public string ValidAudience { get; set; }

        public SymmetricSecurityKey IssuerSigningKey { get; set; }

        public JwtConfig(IConfiguration configuration)
        {
            ValidIssuer = configuration["VALID_ISSUER"] ?? "BestProject";
            ValidAudience = configuration["VALID_AUDIENCE"] ?? "BestGuys";
            var secretKey = Encoding.UTF8.GetBytes(configuration["JWT_SECRET_KEY"] ?? "BestProjectSecretKey!2024");
            IssuerSigningKey = new SymmetricSecurityKey(secretKey);
        }
    }
}
