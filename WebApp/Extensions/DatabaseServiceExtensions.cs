using Microsoft.EntityFrameworkCore;

namespace WebApp.Extensions;

public static class DatabaseServiceExtensions
{
    public static IServiceCollection AddMysqlDatabase<TContext>(this IServiceCollection services)
        where TContext : DbContext
    {
        //services.AddDbContext<ApplicationDbContext>(options =>
        //    options.UseSqlServer(GetDbConnectionFromEnv()));
        //services.AddDatabaseDeveloperPageExceptionFilter();

        return services;
    }

    public static string GetDbConnectionFromEnv(this IConfiguration configuration)
    {
        var server = configuration["SQL_SERVER"] ?? "localhost";
        var database = configuration["SQL_DATABASE"] ?? "BestProjectDb";
        return $"Server={server};Database={database};Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
