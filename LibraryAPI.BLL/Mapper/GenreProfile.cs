using AutoMapper;
using LibraryAPI.BLL.DTOs.Genre;
using LibraryAPI.DAL.Entities;

namespace LibraryAPI.BLL.Mapper;

public class GenreProfile : Profile
{
    public GenreProfile()
    {
        CreateMap<Genre, GetGenreDto>();

        CreateMap<CreateGenreDto, Genre>();

        CreateMap<UpdateGenreDto, Genre>();
    }
}