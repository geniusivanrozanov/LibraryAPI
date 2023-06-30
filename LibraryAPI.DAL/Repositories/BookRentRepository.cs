using AutoMapper;
using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class BookRentRepository : Repository<BookRent, Guid, LibraryDbContext>, IBookRentRepository
{
    public BookRentRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<TProjection>> GetAllBookRentsAsync<TProjection>()
    {
        var rents = await Get<TProjection>()
            .ToListAsync();

        return rents;
    }

    public async Task<IEnumerable<TProjection>> GetBookRentsByBookIdAsync<TProjection>(Guid bookId)
    {
        var rents = await Get<TProjection>(r => r.Book.Id.Equals(bookId))
            .ToListAsync();

        return rents;
    }

    public async Task<IEnumerable<TProjection>> GetBookRentsByUserIdAsync<TProjection>(Guid userId)
    {
        var rents = await Get<TProjection>(r => r.User.Id.Equals(userId))
            .ToListAsync();

        return rents;
    }

    public async Task<TProjection?> GetBookRentByIdAsync<TProjection>(Guid id)
    {
        var rent = await Get<TProjection>(id);

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