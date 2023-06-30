using FluentValidation;
using LibraryAPI.DAL.Entities.Configurations;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.AuthorDtoValidator;

public abstract class AuthorDtoValidator<TDto> : AbstractValidator<TDto>
    where TDto : DTOs.Author.AuthorDto
{
    protected readonly IRepositoryManager RepositoryManager;
    
    protected AuthorDtoValidator(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
        
        RuleFor(dto => dto.FirstName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(AuthorConfiguration.FirstNameMaxLength);
        
        RuleFor(dto => dto.LastName)
            .NotNull()
            .NotEmpty()
            .MaximumLength(AuthorConfiguration.LastNameMaxLength);
    }
}