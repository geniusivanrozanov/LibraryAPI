using AutoMapper;
using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.DAL.Repositories;

public class GenreRepository : Repository<Genre, Guid, LibraryDbContext>, IGenreRepository
{
    public GenreRepository(LibraryDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<TProjection>> GetAllGenresAsync<TProjection>()
    {
        var genres = await Get<TProjection>()
            .ToListAsync();

        return genres;
    }

    public async Task<IEnumerable<TProjection>> GetGenresByBookIdAsync<TProjection>(Guid bookId)
    {
        var genres = await Get<TProjection>(g => g.Books.Any(b => b.Id.Equals(bookId)))
            .ToListAsync();

        return genres;
    }

    public async Task<TProjection?> GetGenreByIdAsync<TProjection>(Guid id)
    {
        var genre = await Get<TProjection>(id);

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

    public async Task<bool> ExistsWithNameAsync(string name)
    {
        return await Get<Genre>(g => g.Name == name)
            .AnyAsync();
    }
}