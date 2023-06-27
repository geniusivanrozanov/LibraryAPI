using FluentValidation.Results;

namespace LibraryAPI.BLL.Interfaces.Validators;

public interface IValidatorManager
{
    ValidationResult Validate<T>(T instance);

    Task<ValidationResult> ValidateAsync<T>(T instance, CancellationToken cancellation = new CancellationToken());
}