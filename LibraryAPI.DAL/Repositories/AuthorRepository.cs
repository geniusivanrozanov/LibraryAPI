using AutoMapper;
using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class AuthorRepository : Repository<Author, Guid, LibraryDbContext>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<TProjection>> GetAllAuthorsAsync<TProjection>()
    {
        var authors = await Get<TProjection>()
            .ToListAsync();

        return authors;
    }

    public async Task<IEnumerable<TProjection>> GetAuthorsByBookIdAsync<TProjection>(Guid bookId)
    {
        var authors = await Get<TProjection>(a => a.Books.Any(b => b.Id.Equals(bookId)))
            .ToListAsync();

        return authors;
    }

    public async Task<TProjection?> GetAuthorByIdAsync<TProjection>(Guid id)
    {
        var author = await Get<TProjection>(id);

        return author;
    }

    public void CreateAuthor(Author author)
    {
        Create(author);
    }

    public void UpdateAuthor(Author author)
    {
        Update(author);
    }

    public void DeleteAuthor(Author author)
    {
        Delete(author);
    }

    public async Task<bool> ExistsWithFirstNameAndLastNameAsync(string firstName, string lastName)
    {
        return await Get<Author>(a => a.FirstName == firstName && a.LastName == lastName)
            .AnyAsync();
    }
}