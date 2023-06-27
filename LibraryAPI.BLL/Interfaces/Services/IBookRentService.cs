using LibraryAPI.BLL.DTOs.BookRent;

namespace LibraryAPI.BLL.Interfaces.Services;

public interface IBookRentService
{
    Task<IEnumerable<GetBookRentDto>> GetAllBookRentsAsync();

    Task<GetBookRentDto> GetBookRentByIdAsync(Guid id);

    Task<GetBookRentDto> CreateBookRentAsync(CreateBookRentDto bookRentDto);

    Task<GetBookRentDto> UpdateBookRentAsync(Guid id, UpdateBookRentDto bookRentDto);

    Task<GetBookRentDto> DeleteBookRentAsync(Guid id);
}