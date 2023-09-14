using LibraryAPI.BLL.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.BLL.Extensions;

public static class DataInitializer
{
    public static IServiceCollection InitializeDatabase(this IServiceCollection services,
        IConfiguration configuration)
    {
        var scope = services.BuildServiceProvider().CreateScope();
        scope.EnsureRolesCreatedAsync().Wait();
        scope.EnsureDefaultUsersCreatedAsync(configuration).Wait();
        
        return services;
    }
    
    private static async Task<IServiceScope> EnsureRolesCreatedAsync(this IServiceScope scope)
    {
        var roles = Roles.AllRoles;
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<Guid>>>();
        var existingRoles = roleManager.Roles
            .Select(r => r.Name)
            .ToList();

        foreach (var role in roles)
        {
            if (!existingRoles.Contains(role))
            {
                await roleManager.CreateAsync(new IdentityRole<Guid>(role));
            }
        }

        return scope;
    }
}