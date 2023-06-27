using System.Reflection;
using FluentValidation;
using LibraryAPI.BLL.Interfaces.Validators;
using LibraryAPI.BLL.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.BLL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.ConfigureAutomapper();
        services.ConfigureValidators();

        return services;
    }
    
    private static IServiceCollection ConfigureAutomapper(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        
        return services;
    }

    private static IServiceCollection ConfigureValidators(this IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddScoped<IValidatorManager, ValidatorManager>();
        
        return services;
    }
}