using FluentValidation;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.Book;

public class CreateBookDtoValidator : BookDtoValidator<CreateBookDto>
{
    public CreateBookDtoValidator() : base()
    {
        
    }
}