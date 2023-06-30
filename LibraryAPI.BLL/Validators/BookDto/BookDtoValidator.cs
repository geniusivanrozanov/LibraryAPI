using FluentValidation;
using LibraryAPI.DAL.Entities.Configurations;
using LibraryAPI.DAL.Interfaces.Repositories;
using Nager.ArticleNumber;

namespace LibraryAPI.BLL.Validators.BookDto;

public abstract class BookDtoValidator<T> : AbstractValidator<T>
    where T : DTOs.Book.BookDto
{
    protected readonly IRepositoryManager RepositoryManager;
    
    protected BookDtoValidator(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
        
        RuleFor(b => b.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(BookConfiguration.NameMaxLength);

        RuleFor(b => b.ISBN)
            .NotNull()
            .NotEmpty()
            .MaximumLength(BookConfiguration.ISBNMaxLength)
            .Must((isbn) => ArticleNumberHelper.IsValidIsbn10(isbn) || ArticleNumberHelper.IsValidIsbn13(isbn));

        RuleFor(b => b.Description)
            .MaximumLength(BookConfiguration.DescriptionMaxLength);
    }
}