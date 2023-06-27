using AutoMapper;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.DAL.Entities;

namespace LibraryAPI.BLL.Mapper;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, GetBookDto>()
            .ForMember(dto => dto.Genres, opt => opt.MapFrom<GenresResolver>())
            .ForMember(dto => dto.Authors, opt => opt.MapFrom<AuthorsResolver>());

        CreateMap<CreateBookDto, Book>();

        CreateMap<UpdateBookDto, Book>();
    }
}

public class GenresResolver : IValueResolver<Book, GetBookDto, string>
{
    public string Resolve(Book source, GetBookDto destination, string destMember, ResolutionContext context)
    {
        return source.Genres is null ? string.Empty : string.Join(", ", source.Genres.Select(g => g.Name));
    }
}

public class AuthorsResolver : IValueResolver<Book, GetBookDto, string>
{
    public string Resolve(Book source, GetBookDto destination, string destMember, ResolutionContext context)
    {
        return source.Authors is null ? string.Empty : string.Join(", ", source.Authors.Select(a => $"{a.FirstName} {a.LastName}"));
    }
}