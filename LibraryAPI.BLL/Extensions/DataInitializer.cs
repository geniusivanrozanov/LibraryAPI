using LibraryAPI.BLL.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.BLL.Extensions;

public static class DataInitializer
{
    public static async Task<IServiceCollection> InitializeDatabaseAsync(this IServiceCollection services,
        IConfiguration configuration)
    {
        var scope = services.BuildServiceProvider().CreateScope();
        await scope.EnsureRolesCreatedAsync();
        
        return services;
    }
    
    private static async Task<IServiceScope> EnsureRolesCreatedAsync(this IServiceScope scope)
    {
        var roles = new string[]
        {
            Roles.Admin,
            Roles.User
        };
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