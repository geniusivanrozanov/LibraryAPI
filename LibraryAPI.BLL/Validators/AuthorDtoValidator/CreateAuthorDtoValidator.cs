using FluentValidation;
using LibraryAPI.BLL.DTOs.Author;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.AuthorDtoValidator;

public class CreateAuthorDtoValidator : AuthorDtoValidator<CreateAuthorDto>
{
    public CreateAuthorDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
        RuleFor(dto => new { dto.FirstName, dto.LastName })
            .MustAsync(async (dto, cancellation) =>
            {
                var exists = await RepositoryManager.Authors
                    .ExistsWithFirstNameAndLastNameAsync(dto.FirstName, dto.LastName);
                
                return exists ? throw new AlreadyExistsException($"Author with first name '{dto.FirstName}' and last name '{dto.LastName}' already exists.") : !exists;
            });
    }
}