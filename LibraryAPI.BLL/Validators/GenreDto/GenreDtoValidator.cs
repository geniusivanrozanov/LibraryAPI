using FluentValidation;
using LibraryAPI.DAL.Entities.Configurations;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.GenreDto;

public abstract class GenreDtoValidator<TDto> : AbstractValidator<TDto>
    where TDto : DTOs.Genre.GenreDto
{
    protected readonly IRepositoryManager RepositoryManager;
    
    protected GenreDtoValidator(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
        
        RuleFor(dto => dto.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(GenreConfiguration.NameMaxLength);
    }
}