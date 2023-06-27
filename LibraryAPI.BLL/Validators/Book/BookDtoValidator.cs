using FluentValidation;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.DAL.Entities.Configurations;

namespace LibraryAPI.BLL.Validators.Book;

public abstract class BookDtoValidator<T> : AbstractValidator<T>
    where T : BookDto
{
    protected BookDtoValidator()
    {
        RuleFor(b => b.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(BookConfiguration.NameMaxLength);

        RuleFor(b => b.ISBN)
            .NotNull()
            .NotEmpty()
            .MaximumLength(BookConfiguration.ISBNMaxLength);

        RuleFor(b => b.Description)
            .MaximumLength(BookConfiguration.DescriptionMaxLength);
    }
}