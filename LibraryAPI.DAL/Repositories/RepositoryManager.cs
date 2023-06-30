using AutoMapper;
using LibraryAPI.DAL.Contexts;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.DAL.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly LibraryDbContext _context;
    private readonly IMapper _mapper;
    
    private IAuthorRepository? _authorRepository;
    private IBookRentRepository? _bookRentRepository;
    private IBookRepository? _bookRepository;
    private IGenreRepository? _genreRepository;

    public RepositoryManager(LibraryDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context, _mapper);
    public IBookRentRepository BookRents => _bookRentRepository ??= new BookRentRepository(_context, _mapper);
    public IBookRepository Books => _bookRepository ??= new BookRepository(_context, _mapper);
    public IGenreRepository Genres => _genreRepository ??= new GenreRepository(_context, _mapper);
    
    public void Save()
    {
        _context.SaveChanges();
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}