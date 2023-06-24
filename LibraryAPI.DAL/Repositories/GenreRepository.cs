using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class GenreRepository : Repository<Genre, Guid, LibraryDbContext>, IGenreRepository
{
    public GenreRepository(LibraryDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Genre>> GetAllGenresAsync()
    {
        var genres = await Get()
            .ToListAsync();

        return genres;
    }

    public async Task<IEnumerable<Genre>> GetGenresByBookIdAsync(Guid bookId)
    {
        var genres = await Get(g => g.Books.Any(b => b.Id.Equals(bookId)))
            .ToListAsync();

        return genres;
    }

    public async Task<Genre?> GetGenreByIdAsync(Guid id)
    {
        var genre = await Get(g => g.Id.Equals(id))
            .SingleOrDefaultAsync();

        return genre;
    }

    public void CreateGenre(Genre genre)
    {
        Create(genre);
    }

    public void UpdateGenre(Genre genre)
    {
        Update(genre);
    }

    public void DeleteGenre(Genre genre)
    {
        Delete(genre);
    }
}