using FluentValidation;
using FluentValidation.Results;
using LibraryAPI.BLL.Interfaces.Validators;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryAPI.BLL.Validators;

public class ValidatorManager : IValidatorManager
{
    private readonly IServiceProvider _serviceProvider;

    public ValidatorManager(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ValidationResult Validate<T>(T instance)
    {
        var validator =  _serviceProvider.GetRequiredService<IValidator<T>>();

        return validator.Validate(instance);
    }

    public async Task<ValidationResult> ValidateAsync<T>(T instance, CancellationToken cancellation = new())
    {
        var validator =  _serviceProvider.GetRequiredService<IValidator<T>>();

        return await validator.ValidateAsync(instance, cancellation);
    }
}