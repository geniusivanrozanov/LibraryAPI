using AutoMapper;
using LibraryAPI.BLL.DTOs.BookRent;
using LibraryAPI.DAL.Entities;

namespace LibraryAPI.BLL.Mapper;

public class BookRentProfile : Profile
{
    public BookRentProfile()
    {
        CreateMap<BookRent, GetBookRentDto>();

        CreateMap<CreateBookRentDto, BookRent>();

        CreateMap<UpdateBookRentDto, BookRent>();
    }
}