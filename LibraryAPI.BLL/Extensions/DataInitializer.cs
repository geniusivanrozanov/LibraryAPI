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

    private static async Task<IServiceScope> EnsureDefaultUsersCreatedAsync(this IServiceScope scope, IConfiguration configuration)
    {
        var defaultUsers = configuration
            .GetSection("DefaultUsers")
            .GetChildren();
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser<Guid>>>();
        
        foreach (var defaultUser in defaultUsers)
        {
            var username = defaultUser["UserName"];
            var password = defaultUser["Password"];
            var role = defaultUser["Role"];
            
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
            {
                await EnsureUserCreated(userManager, username, password, role ?? Roles.User);
            }

        }

        return scope;
    }

    private static async Task EnsureUserCreated(UserManager<IdentityUser<Guid>> userManager, string username, string password, string role)
    {
        var user = await userManager.FindByNameAsync(username);
        if (user is null)
        {
            user = new IdentityUser<Guid>
            {
                UserName = username
            };
             
            await userManager.CreateAsync(user, password);
            await userManager.AddToRoleAsync(user, role);
        }
        else
        {
            if (!await userManager.IsInRoleAsync(user, role))
            {
                await userManager.AddToRoleAsync(user, role);
            }

            if (!await userManager.CheckPasswordAsync(user, password))
            {
                var token = await userManager.GeneratePasswordResetTokenAsync(user);
                await userManager.ResetPasswordAsync(user, token, password);
            }
        }
    }
}