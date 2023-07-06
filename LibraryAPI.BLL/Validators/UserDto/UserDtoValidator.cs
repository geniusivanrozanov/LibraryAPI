using FluentValidation;

namespace LibraryAPI.BLL.Validators.UserDto;

public abstract class UserDtoValidator<TDto> : AbstractValidator<TDto>
    where TDto : DTOs.User.UserDto
{
    protected UserDtoValidator()
    {
        RuleFor(dto => dto.UserName)
            .NotNull()
            .NotEmpty();
        
        RuleFor(dto => dto.Password)
            .NotNull()
            .NotEmpty();
    }
}