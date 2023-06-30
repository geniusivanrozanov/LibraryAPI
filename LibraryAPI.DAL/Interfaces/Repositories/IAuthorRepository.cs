using LibraryAPI.DAL.Entities;

namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IAuthorRepository
{
    Task<IEnumerable<TProjection>> GetAllAuthorsAsync<TProjection>();

    Task<IEnumerable<TProjection>> GetAuthorsByBookIdAsync<TProjection>(Guid bookId);

    Task<TProjection?> GetAuthorByIdAsync<TProjection>(Guid id);

    void CreateAuthor(Author author);
    
    void UpdateAuthor(Author author);
    
    void DeleteAuthor(Author author);

    Task<bool> ExistsAsync(Guid id);

    Task<bool> ExistsWithFirstNameAndLastNameAsync(string firstName, string lastName);
}