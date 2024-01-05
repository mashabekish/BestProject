using BusinessLayer.Abstractions;
using BusinessLayer.Services;
using BusinessLayer.Utils;
using Domain;
using Domain.Abstractions;
using Domain.DataSeeder;
using Domain.Repositories;
using WebApp.Extensions;
using WebApp.Middleware;

namespace WebApp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddJwtAuthentication();

        builder.Services.AddControllers();

        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSqlServerDatabase<AppDbContext>();

        builder.Services.AddScoped<IUserRepository, UserRepository>();
        builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
        builder.Services.AddScoped<IItemRepository, ItemRepository>();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<ICategoryService, CategoryService>();
        builder.Services.AddScoped<IItemService, ItemService>();
        builder.Services.AddScoped<IDbSeeder, DbSeeder>();
        builder.Services.AddAutoMapper(typeof(MapperProfile));

        builder.Services.AddSwagger();

        builder.Services.AddCors(policyBuilder =>
            policyBuilder.AddDefaultPolicy(policy =>
                policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
        );

        var app = builder.Build();

        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        SeedDatabase();

        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseMiddleware<GlobalErrorHandlerMiddleware>();

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
