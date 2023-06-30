using AutoMapper;
using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class BookRepository : Repository<Book, Guid, LibraryDbContext>, IBookRepository
{
    public BookRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }
    
    public async Task<IEnumerable<TProjection>> GetAllBooksAsync<TProjection>()
    {
        var books = await Get<TProjection>()
            .ToListAsync();

        return books;
    }

    public async Task<IEnumerable<TProjection>> GetBooksByAuthorIdAsync<TProjection>(Guid authorId)
    {
        var books = await Get<TProjection>(b => b.Authors.Any(a => a.Id.Equals(authorId)))
            .ToListAsync();

        return books;
    }

    public async Task<IEnumerable<TProjection>> GetBooksByGenreIdAsync<TProjection>(Guid genreId)
    {
        var books = await Get<TProjection>(b => b.Genres.Any(a => a.Id.Equals(genreId)))
            .ToListAsync();

        return books;
    }

    public async Task<TProjection?> GetBookByIdAsync<TProjection>(Guid id)
    {
        var book = await Get<TProjection>(id);

        return book;
    }

    public async Task<TProjection?> GetBookByISBNAsync<TProjection>(string isbn)
    {
        var book = await Get<TProjection>(b => b.ISBN == isbn)
            .SingleOrDefaultAsync();

        return book;
    }

    public void CreateBook(Book book)
    {
        Create(book);
    }

    public void UpdateBook(Book book)
    {
        Update(book);
    }

    public void DeleteBook(Book book)
    {
        Delete(book);
    }

    public async Task<bool> ExistsWithNameAsync(string name)
    {
        return await Get<Book>(b => b.Name == name)
            .AnyAsync();
    }

    public async Task<bool> ExistsWithISBNAsync(string isbn)
    {
        return await Get<Book>(b => b.ISBN == isbn)
            .AnyAsync();
    }
}