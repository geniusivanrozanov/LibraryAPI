using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.DAL.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly LibraryDbContext _context;
    
    private IAuthorRepository? _authorRepository;
    private IBookRentRepository? _bookRentRepository;
    private IBookRepository? _bookRepository;
    private IGenreRepository? _genreRepository;

    public RepositoryManager(LibraryDbContext context)
    {
        _context = context;
    }

    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context);
    public IBookRentRepository BookRents => _bookRentRepository ??= new BookRentRepository(_context);
    public IBookRepository Books => _bookRepository ??= new BookRepository(_context);
    public IGenreRepository Genres => _genreRepository ??= new GenreRepository(_context);
    
    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}