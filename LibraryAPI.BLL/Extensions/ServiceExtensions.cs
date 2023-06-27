using System.Reflection;
using FluentValidation;
using LibraryAPI.BLL.Interfaces.Services;
using LibraryAPI.BLL.Interfaces.Validators;
using LibraryAPI.BLL.Services;
using LibraryAPI.BLL.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.BLL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
    {
        services.ConfigureAutomapper()
            .ConfigureValidators()
            .AddServices();

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

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();

        return services;
    }
}