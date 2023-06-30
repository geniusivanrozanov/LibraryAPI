using FluentValidation;
using LibraryAPI.BLL.DTOs.Genre;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.GenreDto;

public class UpdateGenreDtoValidator : GenreDtoValidator<UpdateGenreDto>
{
    public UpdateGenreDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
        RuleFor(b => new { b.Id, b.Name })
            .MustAsync(async (dto, cancellation) =>
            {
                var genreEntity = await repositoryManager.Genres.GetGenreByIdAsync<Genre>(dto.Id);

                if (genreEntity?.Name == dto.Name)
                {
                    return true;
                }
                
                var exists = await RepositoryManager.Genres
                    .ExistsWithNameAsync(dto.Name);

                return exists ? throw new AlreadyExistsException($"Genre with name '{dto.Name}' already exists.") : !exists;
            });
    }
}