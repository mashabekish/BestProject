using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApp.Models;

namespace WebApp.Extensions;

public static class AuthenticationServiceExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();

        var jwtConfig = new JwtConfig(configuration);

        services.AddSingleton(jwtConfig);
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfig.ValidIssuer,
                    ValidateAudience = true,
                    ValidAudience = jwtConfig.ValidAudience,
                    ValidateLifetime = true,
                    IssuerSigningKey = jwtConfig.IssuerSigningKey,
                    ValidateIssuerSigningKey = true,
                };
            });
        return services;
    }
}
