using LibraryAPI.BLL.DTOs.BookRent;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.BookRentDto;

public class CreateBookRentDtoValidator : BookRentDtoValidator<CreateBookRentDto>
{
    public CreateBookRentDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
    }
}