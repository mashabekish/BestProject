using Domain;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions;

public static class DatabaseServiceExtensions
{
    public static IServiceCollection AddSqlServerDatabase<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        var provider = services.BuildServiceProvider();
        var configuration = provider.GetRequiredService<IConfiguration>();

        var connectionString = configuration.GetDbConnectionFromEnv();
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connectionString));

        return services;
    }

    public static string GetDbConnectionFromEnv(this IConfiguration configuration)
    {
        var server = configuration["SQL_SERVER"] ?? "localhost";
        var database = configuration["SQL_DATABASE"] ?? "BestProjectDb";
        return $"Server={server};Database={database};Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
