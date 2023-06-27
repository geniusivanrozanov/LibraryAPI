using AutoMapper;
using LibraryAPI.BLL.DTOs.Author;
using LibraryAPI.DAL.Entities;

namespace LibraryAPI.BLL.Mapper;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, GetAuthorDto>();

        CreateMap<CreateAuthorDto, Author>();
        
        CreateMap<UpdateAuthorDto, Author>();
    }
}