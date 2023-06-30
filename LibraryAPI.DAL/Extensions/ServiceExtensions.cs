using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Interfaces.Repositories;
using LibraryAPI.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LibraryAPI.DAL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureLibraryDbContext(configuration);
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        
        return services;
    }
    
    private static IServiceCollection ConfigureLibraryDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var libraryConnectionString = configuration.GetConnectionString("LibraryConnectionString");
        ArgumentNullException.ThrowIfNull(libraryConnectionString);
        
        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseNpgsql(libraryConnectionString);
            options.UseLazyLoadingProxies();
        });

        services.BuildServiceProvider()
            .MigrateDatabase<LibraryDbContext>();
        
        return services;
    }

    private static IServiceProvider MigrateDatabase<TContext>(this IServiceProvider serviceProvider)
        where TContext : DbContext
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetRequiredService<TContext>();
        try
        {
            context.Database.Migrate();
        }
        catch (Exception)
        {
            var logger = scope.ServiceProvider.GetRequiredService<ILogger<TContext>>();
            logger.LogError("An error occurred while migrating the database");
            
            throw;
        }

        return serviceProvider;
    }
}