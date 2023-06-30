using FluentValidation;
using LibraryAPI.BLL.DTOs.Author;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Validators.AuthorDtoValidator;

public class UpdateAuthorDtoValidator : AuthorDtoValidator<UpdateAuthorDto>
{
    public UpdateAuthorDtoValidator(IRepositoryManager repositoryManager) : base(repositoryManager)
    {
        RuleFor(dto => new { dto.Id, dto.FirstName, dto.LastName })
            .MustAsync(async (dto, cancellation) =>
            {
                var authorEntity = await repositoryManager.Authors.GetAuthorByIdAsync<Author>(dto.Id);

                if (authorEntity?.FirstName == dto.FirstName && authorEntity?.LastName == dto.LastName)
                {
                    return true;
                }
                
                var exists = await RepositoryManager.Authors
                    .ExistsWithFirstNameAndLastNameAsync(dto.FirstName, dto.LastName);
                
                return exists ? throw new AlreadyExistsException($"Author with first name '{dto.FirstName}' and last name '{dto.LastName}' already exists.") : !exists;
            });
    }
}