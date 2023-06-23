using LibraryAPI.DAL.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.DAL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddDataAccessLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.ConfigureLibraryDbContext(configuration);
        
        return services;
    }
    
    public static IServiceCollection ConfigureLibraryDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var libraryConnectionString = configuration.GetConnectionString("LibraryConnectionString");
        ArgumentNullException.ThrowIfNull(libraryConnectionString);

        services.AddDbContext<LibraryDbContext>(options =>
        {
            options.UseNpgsql(libraryConnectionString);
        });
        
        return services;
    }
}