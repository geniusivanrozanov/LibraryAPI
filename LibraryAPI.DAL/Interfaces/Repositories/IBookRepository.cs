using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<TProjection>> GetAllBooksAsync<TProjection>();

    Task<IEnumerable<TProjection>> GetBooksByAuthorIdAsync<TProjection>(Guid authorId);

    Task<IEnumerable<TProjection>> GetBooksByGenreIdAsync<TProjection>(Guid genreId);
    
    Task<TProjection?> GetBookByIdAsync<TProjection>(Guid id);

    Task<TProjection?> GetBookByISBNAsync<TProjection>(string isbn);

    void CreateBook(Book book);
    
    void UpdateBook(Book book);

    void DeleteBook(Book book);
    
    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsWithNameAsync(string name);

    Task<bool> ExistsWithISBNAsync(string isbn);
}