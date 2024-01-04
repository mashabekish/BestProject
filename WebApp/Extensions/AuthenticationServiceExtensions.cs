using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApp.Services;

namespace WebApp.Extensions;

public static class AuthenticationServiceExtensions
{
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services)
    {
        services.AddSingleton<JwtService>();

        var provider = services.BuildServiceProvider();
        var authentication = provider.GetRequiredService<JwtService>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = authentication.ValidIssuer,
                    ValidateAudience = true,
                    ValidAudience = authentication.ValidAudience,
                    ValidateLifetime = true,
                    IssuerSigningKey = authentication.IssuerSigningKey,
                    ValidateIssuerSigningKey = true,
                };
            });
        return services;
    }
}
