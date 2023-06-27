using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IBookRentRepository
{
    Task<IEnumerable<BookRent>> GetAllBookRentsAsync();

    Task<IEnumerable<BookRent>> GetBookRentsByBookIdAsync(Guid bookId);

    Task<IEnumerable<BookRent>> GetBookRentsByUserIdAsync(Guid userId);

    Task<BookRent?> GetBookRentByIdAsync(Guid id);

    void CreateBookRent(BookRent bookRent);

    void UpdateBookRent(BookRent bookRent);

    void DeleteBookRent(BookRent bookRent);
    
    Task<bool> ExistsAsync(Guid id);
}