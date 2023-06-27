using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooksAsync();

    Task<IEnumerable<Book>> GetBooksByAuthorIdAsync(Guid authorId);

    Task<IEnumerable<Book>> GetBooksByGenreIdAsync(Guid genreId);
    
    Task<Book?> GetBookByIdAsync(Guid id);

    Task<Book?> GetBookByISBNAsync(string isbn);

    void CreateBook(Book book);
    
    void UpdateBook(Book book);

    void DeleteBook(Book book);
    
    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsWithNameAsync(string name);

    Task<bool> ExistsWithISBNAsync(string isbn);
}