using System.ComponentModel.DataAnnotations;
using FluentValidation;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.BookRentDto;

public class BookRentDtoValidator<TDto> : AbstractValidator<TDto>
    where TDto : DTOs.BookRent.BookRentDto
{
    protected readonly IRepositoryManager RepositoryManager;
    
    public BookRentDtoValidator(IRepositoryManager repositoryManager)
    {
        RepositoryManager = repositoryManager;
        
        RuleFor(dto => dto.ReturnDate)
            .GreaterThan(DateTime.Now);
        
        RuleFor(b => b.BookId)
            .MustAsync(async (id, cancellation) =>
            {
                var exists = await RepositoryManager.Books
                    .ExistsAsync(id);

                return exists;
            });
    }
}