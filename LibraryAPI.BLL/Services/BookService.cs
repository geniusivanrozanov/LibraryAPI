using AutoMapper;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.BLL.Interfaces.Services;
using LibraryAPI.BLL.Interfaces.Validators;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Services;

public class BookService : IBookService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IValidatorManager _validatorManager;
    private readonly IMapper _mapper;

    public BookService(IRepositoryManager repositoryManager, IMapper mapper, IValidatorManager validatorManager)
    {
        _repositoryManager = repositoryManager;
        _mapper = mapper;
        _validatorManager = validatorManager;
    }

    public async Task<IEnumerable<GetBookDto>> GetAllBooksAsync()
    {
        var booksDto = await _repositoryManager.Books.GetAllBooksAsync<GetBookDto>();

        return booksDto;
    }

    public async Task<GetBookDto> GetBookByIdAsync(Guid id)
    {
        var bookDto = await _repositoryManager.Books.GetBookByIdAsync<GetBookDto>(id);
        if (bookDto is null)
        {
            throw new NotExistsException($"Book with id '{id}' doesn't exist.");
        }

        return bookDto;
    }

    public async Task<GetBookDto> CreateBookAsync(CreateBookDto createBookDto)
    {
        var validationResults = await _validatorManager.ValidateAsync(createBookDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }
        
        var bookEntity = _mapper.Map<Book>(createBookDto);
        _repositoryManager.Books.CreateBook(bookEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetBookDto>(bookEntity);
    }

    public async Task<GetBookDto> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto)
    {
        if (updateBookDto.Id != id)
        {
            throw new IdentifierMismatchException($"Book.id '{updateBookDto.Id}' doesn't match id '{id}'.");
        }
        
        var bookEntity = await _repositoryManager.Books.GetBookByIdAsync<Book>(id);
        if (bookEntity is null)
        {
            throw new NotExistsException($"Book with id '{id}' doesn't exist.");
        }
        
        var validationResults = await _validatorManager.ValidateAsync(updateBookDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        _mapper.Map(updateBookDto, bookEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetBookDto>(bookEntity);
    }

    public async Task DeleteBookAsync(Guid id)
    {
        if (!await _repositoryManager.Books.ExistsAsync(id))
        {
            throw new NotExistsException($"Book with id '{id}' doesn't exist.");
        }

        var bookEntity = new Book() { Id = id };
        _repositoryManager.Books.DeleteBook(bookEntity);
        await _repositoryManager.SaveAsync();
    }

    public async Task AddBookAuthorAsync(Guid bookId, Guid authorId)
    {
        var bookEntity = await _repositoryManager.Books.GetBookByIdAsync<Book>(bookId);
        if (bookEntity is null)
        {
            throw new NotExistsException($"Book with id '{bookId}' doesn't exist.");
        }
        
        var authorEntity = await _repositoryManager.Authors.GetAuthorByIdAsync<Author>(authorId);
        if (authorEntity is null)
        {
            throw new NotExistsException($"Author with id '{authorId}' doesn't exist.");
        }

        bookEntity.Authors ??= new List<Author>();
        bookEntity.Authors.Add(authorEntity);
        await _repositoryManager.SaveAsync();
    }

    public async Task RemoveBookAuthorAsync(Guid bookId, Guid authorId)
    {
        var bookEntity = await _repositoryManager.Books.GetBookByIdAsync<Book>(bookId);
        if (bookEntity is null)
        {
            throw new NotExistsException($"Book with id '{bookId}' doesn't exist.");
        }

        var authorEntity = bookEntity.Authors?
            .SingleOrDefault(a => a.Id.Equals(authorId));
        if (authorEntity is null)
        {
            throw new NotExistsException($"Book with id '{bookId}' doesn't have author with id '{authorId}'.");
        }

        bookEntity.Authors?.Remove(authorEntity);
        await _repositoryManager.SaveAsync();
    }

    public async Task AddBookGenreAsync(Guid bookId, Guid genreId)
    {
        var bookEntity = await _repositoryManager.Books.GetBookByIdAsync<Book>(bookId);
        if (bookEntity is null)
        {
            throw new NotExistsException($"Book with id '{bookId}' doesn't exist.");
        }
        
        var genreEntity = await _repositoryManager.Genres.GetGenreByIdAsync<Genre>(genreId);
        if (genreEntity is null)
        {
            throw new NotExistsException($"Genre with id '{genreId}' doesn't exist.");
        }

        bookEntity.Genres ??= new List<Genre>();
        bookEntity.Genres.Add(genreEntity);
        _repositoryManager.Books.UpdateBook(bookEntity);
        await _repositoryManager.SaveAsync();
    }

    public async Task RemoveBookGenreAsync(Guid bookId, Guid genreId)
    {
        var bookEntity = await _repositoryManager.Books.GetBookByIdAsync<Book>(bookId);
        if (bookEntity is null)
        {
            throw new NotExistsException($"Book with id '{bookId}' doesn't exist.");
        }

        var genreEntity = bookEntity.Genres?
            .SingleOrDefault(a => a.Id.Equals(genreId));
        if (genreEntity is null)
        {
            throw new NotExistsException($"Book with id '{bookId}' doesn't have genre with id '{genreId}'.");
        }

        bookEntity.Genres?.Remove(genreEntity);
        await _repositoryManager.SaveAsync();
    }
}