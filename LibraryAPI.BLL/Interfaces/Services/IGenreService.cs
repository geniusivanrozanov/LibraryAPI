using LibraryAPI.BLL.DTOs.Genre;

namespace LibraryAPI.BLL.Interfaces.Services;

public interface IGenreService
{
    Task<IEnumerable<GetGenreDto>> GetAllGenresAsync();

    Task<GetGenreDto> GetGenreByIdAsync(Guid id);

    Task<GetGenreDto> CreateGenreAsync(CreateGenreDto createGenreDto);

    Task<GetGenreDto> UpdateGenreAsync(Guid id, UpdateGenreDto updateGenreDto);

    Task DeleteGenreAsync(Guid id);
}