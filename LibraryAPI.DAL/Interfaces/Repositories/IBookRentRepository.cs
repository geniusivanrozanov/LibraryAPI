using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IBookRentRepository
{
    Task<IEnumerable<TProjection>> GetAllBookRentsAsync<TProjection>();

    Task<IEnumerable<TProjection>> GetBookRentsByBookIdAsync<TProjection>(Guid bookId);

    Task<IEnumerable<TProjection>> GetBookRentsByUserIdAsync<TProjection>(Guid userId);

    Task<TProjection?> GetBookRentByIdAsync<TProjection>(Guid id);

    void CreateBookRent(BookRent bookRent);

    void UpdateBookRent(BookRent bookRent);

    void DeleteBookRent(BookRent bookRent);
    
    Task<bool> ExistsAsync(Guid id);
}