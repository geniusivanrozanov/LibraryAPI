using LibraryAPI.BLL.DTOs.Author;

namespace LibraryAPI.BLL.Interfaces.Services;

public interface IAuthorService
{
    Task<IEnumerable<GetAuthorDto>> GetAllAuthorsAsync();

    Task<GetAuthorDto> GetAuthorByIdAsync(Guid id);

    Task<GetAuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto);

    Task<GetAuthorDto> UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthorDto);

    Task DeleteAuthorAsync(Guid id);
}