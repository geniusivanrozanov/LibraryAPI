using LibraryAPI.BLL.DTOs.Genre;

namespace LibraryAPI.BLL.Interfaces.Services;

public interface IGenreService
{
    Task<IEnumerable<GetGenreDto>> GetAllGenresAsync();

    Task<GetGenreDto> GetGenreByIdAsync(Guid id);

    Task<GetGenreDto> CreateGenreAsync(CreateGenreDto genreDto);

    Task<GetGenreDto> UpdateGenreAsync(Guid id, UpdateGenreDto genreDto);

    Task<GetGenreDto> DeleteGenreAsync(Guid id);
}