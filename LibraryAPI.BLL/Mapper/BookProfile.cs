using AutoMapper;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.DAL.Entities;

namespace LibraryAPI.BLL.Mapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, GetBookDto>()
            .ForMember(dto => dto.Genres, opt =>
            {
                opt.MapFrom(x => string.Join(", ", x.Genres.Select(g => g.Name)));
            })
            .ForMember(dto => dto.Authors, opt =>
            {
                opt.MapFrom(x => string.Join(", ", x.Authors.Select(a => $"{a.FirstName} {a.LastName}")));
            });

        CreateMap<CreateBookDto, Book>();

        CreateMap<UpdateBookDto, Book>();
    }
}