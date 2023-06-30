using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<TProjection>> GetAllGenresAsync<TProjection>();

    Task<IEnumerable<TProjection>> GetGenresByBookIdAsync<TProjection>(Guid bookId);

    Task<TProjection?> GetGenreByIdAsync<TProjection>(Guid id);

    void CreateGenre(Genre genre);
    
    void UpdateGenre(Genre genre);

    void DeleteGenre(Genre genre);
    
    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsWithNameAsync(string name);
}