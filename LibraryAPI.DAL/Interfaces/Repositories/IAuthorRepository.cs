using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAuthorsAsync();

    Task<IEnumerable<Author>> GetAuthorsByBookIdAsync(Guid bookId);

    Task<Author?> GetAuthorByIdAsync(Guid id);

    void CreateAuthor(Author author);
    
    void UpdateAuthor(Author author);
    
    void DeleteAuthor(Author author);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsWithFirstNameAndLastNameAsync(string firstName, string lastName);
}