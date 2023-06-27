using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IGenreRepository
{
    Task<IEnumerable<Genre>> GetAllGenresAsync();

    Task<IEnumerable<Genre>> GetGenresByBookIdAsync(Guid bookId);

    Task<Genre?> GetGenreByIdAsync(Guid id);

    void CreateGenre(Genre genre);
    
    void UpdateGenre(Genre genre);

    void DeleteGenre(Genre genre);
    
    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsWithNameAsync(string name);
}