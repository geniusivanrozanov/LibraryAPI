using System.Security.Claims;
using AutoMapper;
using LibraryAPI.BLL.DTOs.BookRent;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.BLL.Interfaces.Services;
using LibraryAPI.BLL.Interfaces.Validators;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.BLL.Services;

public class BookRentService : IBookRentService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IValidatorManager _validatorManager;
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly IMapper _mapper;
    
    private readonly ClaimsPrincipal _user;

    public BookRentService(IRepositoryManager repositoryManager, IValidatorManager validatorManager, IMapper mapper, UserManager<IdentityUser<Guid>> userManager, ClaimsPrincipal user)
    {
        _repositoryManager = repositoryManager;
        _validatorManager = validatorManager;
        _mapper = mapper;
        _userManager = userManager;
        _user = user;
    }

    public async Task<IEnumerable<GetBookRentDto>> GetAllBookRentsAsync()
    {
        var bookRentsDto = await _repositoryManager.BookRents.GetAllBookRentsAsync<GetBookRentDto>();

        return bookRentsDto;
    }

    public async Task<GetBookRentDto> GetBookRentByIdAsync(Guid id)
    {
        var bookRentDto = await _repositoryManager.BookRents.GetBookRentByIdAsync<GetBookRentDto>(id);
        if (bookRentDto is null)
        {
            throw new NotExistsException($"Book rent with id '{id}' doesn't exist.");
        }

        return bookRentDto;
    }

    public async Task<GetBookRentDto> CreateBookRentAsync(CreateBookRentDto createBookRentDto)
    {
        var validationResults = await _validatorManager.ValidateAsync(createBookRentDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        var bookRentEntity = _mapper.Map<BookRent>(createBookRentDto);
        
        var userId = _userManager.GetUserId(_user);
        if (userId == null)
        {
            throw new ActorNotRecognizedException("Actor not recognized.");
        }
        
        bookRentEntity.UserId = new Guid(userId);
        _repositoryManager.BookRents.CreateBookRent(bookRentEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetBookRentDto>(bookRentEntity);
    }

    public async Task<GetBookRentDto> UpdateBookRentAsync(Guid id, UpdateBookRentDto updateBookRentDto)
    {
        if (updateBookRentDto.Id != id)
        {
            throw new IdentifierMismatchException($"Book rent id '{updateBookRentDto.Id}' doesn't match id '{id}'.");
        }
        
        
        var bookRentEntity = await _repositoryManager.BookRents.GetBookRentByIdAsync<BookRent>(id);
        if (bookRentEntity is null)
        {
            throw new NotExistsException($"Book rent with id '{id}' doesn't exist.");
        }
        
        var validationResults = await _validatorManager.ValidateAsync(updateBookRentDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        _mapper.Map(updateBookRentDto, bookRentEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetBookRentDto>(bookRentEntity);
    }

    public async Task DeleteBookRentAsync(Guid id)
    {
        if (!await _repositoryManager.BookRents.ExistsAsync(id))
        {
            throw new NotExistsException($"Book rent with id '{id}' doesn't exist.");
        }

        var bookRentEntity = new BookRent() { Id = id };
        _repositoryManager.BookRents.DeleteBookRent(bookRentEntity);
        await _repositoryManager.SaveAsync();
    }
}