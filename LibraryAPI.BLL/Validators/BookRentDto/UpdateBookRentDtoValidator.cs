using LibraryAPI.BLL.DTOs.BookRent;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.BookRentDto;

public class UpdateBookRentDtoValidator : BookRentDtoValidator<UpdateBookRentDto>
{
    public UpdateBookRentDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
    }
}