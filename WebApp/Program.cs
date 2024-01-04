using BusinessLayer.Abstractions;
using BusinessLayer.Services;
using Domain;
using Domain.Abstractions;
using Domain.DataSeeder;
using Domain.Repositories;
using Newtonsoft.Json;
using WebApp.Extensions;

namespace WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddJwtAuthentication();

        builder.Services.AddControllers().AddNewtonsoftJson(options =>
        {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSqlServerDatabase<AppDbContext>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IDbSeeder, DbSeeder>();

        builder.Services.AddSwagger();

        var app = builder.Build();

        app.UseAuthentication();
        app.UseAuthorization();

        SeedDatabase();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();

        app.Run();

        async void SeedDatabase()
        {
            using (var scope = app.Services.CreateScope())
            {
                var dbSeeder = scope.ServiceProvider.GetRequiredService<IDbSeeder>();
               await dbSeeder.SeedData();
            }
        }
    }
}
