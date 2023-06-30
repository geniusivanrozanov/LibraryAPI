using FluentValidation;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.BookDto;

public class CreateBookDtoValidator : BookDtoValidator<CreateBookDto>
{
    public CreateBookDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
        RuleFor(b => b.Name)
            .MustAsync(async (name, cancellation) =>
            {
                var exists = await RepositoryManager.Books
                    .ExistsWithNameAsync(name);

                return exists ? throw new AlreadyExistsException($"Book with name '{name}' already exists.") : !exists;
            });

        RuleFor(b => b.ISBN)
            .MustAsync(async (isbn, cancellation) =>
            {
                var exists = await RepositoryManager.Books
                    .ExistsWithISBNAsync(isbn);
                
                return exists ? throw new AlreadyExistsException($"Book with ISBN '{isbn}' already exists.") : !exists;
            });
    }
}