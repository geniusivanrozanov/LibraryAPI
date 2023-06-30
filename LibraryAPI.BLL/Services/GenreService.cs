using AutoMapper;
using LibraryAPI.BLL.DTOs.Genre;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.BLL.Interfaces.Services;
using LibraryAPI.BLL.Interfaces.Validators;
using LibraryAPI.DAL.Entities;
using LibraryAPI.DAL.Interfaces.Repositories;

namespace LibraryAPI.BLL.Services;

public class GenreService : IGenreService
{
    private readonly IRepositoryManager _repositoryManager;
    private readonly IValidatorManager _validatorManager;
    private readonly IMapper _mapper;

    public GenreService(IRepositoryManager repositoryManager, IValidatorManager validatorManager, IMapper mapper)
    {
        _repositoryManager = repositoryManager;
        _validatorManager = validatorManager;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetGenreDto>> GetAllGenresAsync()
    {
        var genresDto = await _repositoryManager.Genres.GetAllGenresAsync<GetGenreDto>();

        return genresDto;
    }

    public async Task<GetGenreDto> GetGenreByIdAsync(Guid id)
    {
        var genreDto = await _repositoryManager.Genres.GetGenreByIdAsync<GetGenreDto>(id);
        if (genreDto is null)
        {
            throw new NotExistsException($"Genre with id '{id}' doesn't exist.");
        }

        return genreDto;
    }

    public async Task<GetGenreDto> CreateGenreAsync(CreateGenreDto createGenreDto)
    {
        var validationResults = await _validatorManager.ValidateAsync(createGenreDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        var genreEntity = _mapper.Map<Genre>(createGenreDto);
        _repositoryManager.Genres.CreateGenre(genreEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetGenreDto>(genreEntity);
    }

    public async Task<GetGenreDto> UpdateGenreAsync(Guid id, UpdateGenreDto updateGenreDto)
    {
        if (updateGenreDto.Id != id)
        {
            throw new IdentifierMismatchException($"Genre.id '{updateGenreDto.Id}' doesn't match id '{id}'.");
        }
        
        
        var genreEntity = await _repositoryManager.Genres.GetGenreByIdAsync<Genre>(id);
        if (genreEntity is null)
        {
            throw new NotExistsException($"Genre with id '{id}' doesn't exist.");
        }
        
        var validationResults = await _validatorManager.ValidateAsync(updateGenreDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        _mapper.Map(updateGenreDto, genreEntity);
        await _repositoryManager.SaveAsync();

        return _mapper.Map<GetGenreDto>(genreEntity);
    }

    public async Task DeleteGenreAsync(Guid id)
    {
        if (!await _repositoryManager.Genres.ExistsAsync(id))
        {
            throw new NotExistsException($"Genre with id '{id}' doesn't exist.");
        }

        var genreEntity = new Genre() { Id = id };
        _repositoryManager.Genres.DeleteGenre(genreEntity);
        await _repositoryManager.SaveAsync();
    }
}