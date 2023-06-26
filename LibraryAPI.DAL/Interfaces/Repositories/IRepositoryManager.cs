namespace LibraryAPI.DAL.Interfaces.Repositories;

public interface IRepositoryManager
{
    IAuthorRepository Authors { get; }
    IBookRentRepository BookRents { get; }
    IBookRepository Books { get; }
    IGenreRepository Genres { get; }

    void Save();
    Task SaveAsync();
}