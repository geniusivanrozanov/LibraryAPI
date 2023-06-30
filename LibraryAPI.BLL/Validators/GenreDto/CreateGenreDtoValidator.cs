using FluentValidation;
using LibraryAPI.BLL.DTOs.Genre;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.GenreDto;

public class CreateGenreDtoValidator : GenreDtoValidator<CreateGenreDto>
{
    public CreateGenreDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
        RuleFor(dto => dto.Name)
            .MustAsync(async (name, cancellation) =>
            {
                var exists = await RepositoryManager.Genres
                    .ExistsWithNameAsync(name);
                
                return exists ? throw new AlreadyExistsException($"Genre with name '{name}' already exists.") : !exists;
            });
    }
}