using AutoMapper;
using LibraryAPI.BLL.DTOs.Author;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.BLL.Interfaces.Services;
using LibraryAPI.BLL.Interfaces.Validators;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Services;

public class AuthorService : IAuthorService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IValidatorManager _validatorManager;
    private readonly IMapper _mapper;

    public AuthorService(IRepositoryManager repositoryManager, IValidatorManager validatorManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _validatorManager = validatorManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAuthorDto>> GetAllAuthorsAsync()
    {
        var authorsDto = await _repositoryManager.Authors.GetAllAuthorsAsync<GetAuthorDto>();

        return authorsDto;
    }

    public async Task<GetAuthorDto> GetAuthorByIdAsync(Guid id)
    {
        var authorDto = await _repositoryManager.Authors.GetAuthorByIdAsync<GetAuthorDto>(id);
        if (authorDto is null)
        {
            throw new NotExistsException($"Author with id '{id}' doesn't exist.");
        }

        return authorDto;
    }

    public async Task<GetAuthorDto> CreateAuthorAsync(CreateAuthorDto createAuthorDto)
    {
        var validationResults = await _validatorManager.ValidateAsync(createAuthorDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        var authorEntity = _mapper.Map<Author>(createAuthorDto);
        _repositoryManager.Authors.CreateAuthor(authorEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetAuthorDto>(authorEntity);
    }

    public async Task<GetAuthorDto> UpdateAuthorAsync(Guid id, UpdateAuthorDto updateAuthorDto)
    {
        if (updateAuthorDto.Id != id)
        {
            throw new IdentifierMismatchException($"Author.id '{updateAuthorDto.Id}' doesn't match id '{id}'.");
        }
        
        
        var authorEntity = await _repositoryManager.Authors.GetAuthorByIdAsync<Author>(id);
        if (authorEntity is null)
        {
            throw new NotExistsException($"Author with id '{id}' doesn't exist.");
        }
        
        var validationResults = await _validatorManager.ValidateAsync(updateAuthorDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        _mapper.Map(updateAuthorDto, authorEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetAuthorDto>(authorEntity);
    }

    public async Task DeleteAuthorAsync(Guid id)
    {
        if (!await _repositoryManager.Authors.ExistsAsync(id))
        {
            throw new NotExistsException($"Author with id '{id}' doesn't exist.");
        }

        var authorEntity = new Author() { Id = id };
        _repositoryManager.Authors.DeleteAuthor(authorEntity);
        await _repositoryManager.SaveAsync();
    }
}