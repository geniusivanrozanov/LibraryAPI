using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class AuthorRepository : Repository<Author, Guid, LibraryDbContext>, IAuthorRepository
{
    public AuthorRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        var authors = await Get()
            .ToListAsync();

        return authors;
    }

    public async Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(Guid bookId)
    {
        var authors = await Get(a => a.Books.Any(b => b.Id.Equals(bookId)))
            .ToListAsync();

        return authors;
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id)
    {
        var author = await Get(a => a.Id.Equals(id))
            .SingleOrDefaultAsync();

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
}