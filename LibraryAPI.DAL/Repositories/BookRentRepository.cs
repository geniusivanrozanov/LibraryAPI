using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class BookRentRepository : Repository<BookRent, Guid, LibraryDbContext>, IBookRentRepository
{
    public BookRentRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<BookRent>> GetAllBookRentsAsync()
    {
        var rents = await Get()
            .ToListAsync();

        return rents;
    }

    public async Task<IEnumerable<BookRent>> GetBookRentsByBookIdAsync(Guid bookId)
    {
        var rents = await Get(r => r.Book.Id.Equals(bookId))
            .ToListAsync();

        return rents;
    }

    public async Task<IEnumerable<BookRent>> GetBookRentsByUserIdAsync(Guid userId)
    {
        var rents = await Get(r => r.User.Id.Equals(userId))
            .ToListAsync();

        return rents;
    }

    public async Task<BookRent?> GetBookRentByIdAsync(Guid id)
    {
        var rent = await Get(id);

        return rent;
    }

    public async void CreateBookRent(BookRent bookRent)
    {
        Create(bookRent);
    }

    public async void UpdateBookRent(BookRent bookRent)
    {
        Update(bookRent);
    }

    public async void DeleteBookRent(BookRent bookRent)
    {
        Delete(bookRent);
    }
}