using FluentValidation;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.BookDto;

public class UpdateBookDtoValidator : BookDtoValidator<UpdateBookDto>
{
    public UpdateBookDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
        RuleFor(b => new { b.Id, b.Name })
            .MustAsync(async (dto, cancellation) =>
            {
                var bookEntity = await repositoryManager.Books.GetBookByIdAsync<Book>(dto.Id);

                if (bookEntity?.Name == dto.Name)
                {
                    return true;
                }
                
                var exists = await RepositoryManager.Books
                    .ExistsWithNameAsync(dto.Name);

                return exists ? throw new AlreadyExistsException($"Book with name '{dto.Name}' already exists.") : !exists;
            });

        RuleFor(b => new { b.Id, b.ISBN })
            .MustAsync(async (dto, cancellation) =>
            {
                var bookEntity = await repositoryManager.Books.GetBookByIdAsync<Book>(dto.Id);

                if (bookEntity?.ISBN == dto.ISBN)
                {
                    return true;
                }
                
                var exists = await RepositoryManager.Books
                    .ExistsWithISBNAsync(dto.ISBN);
                
                return exists ? throw new AlreadyExistsException($"Book with ISBN '{dto.ISBN}' already exists.") : !exists;
            });
    }
}