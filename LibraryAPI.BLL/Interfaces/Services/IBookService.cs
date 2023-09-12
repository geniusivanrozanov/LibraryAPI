using LibraryAPI.BLL.DTOs.Book;

namespace LibraryAPI.BLL.Interfaces.Services;

public interface IBookService
{
    Task<IEnumerable<GetBookDto>> GetAllBooksAsync();

    Task<GetBookDto> GetBookByIdAsync(Guid id);

    Task<GetBookDto> GetBookByIsbnAsync(string isbn);

    Task<GetBookDto> CreateBookAsync(CreateBookDto createBookDto);

    Task<GetBookDto> UpdateBookAsync(Guid id, UpdateBookDto updateBookDto);

    Task DeleteBookAsync(Guid id);

    Task AddBookAuthorAsync(Guid bookId, Guid authorId);

    Task RemoveBookAuthorAsync(Guid bookId, Guid authorId);

    Task AddBookGenreAsync(Guid bookId, Guid genreId);

    Task RemoveBookGenreAsync(Guid bookId, Guid genreId);
}