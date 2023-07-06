using AutoMapper;
using LibraryAPI.BLL.DTOs.User;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.BLL.Mapper;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegistrationUserDto, IdentityUser<Guid>>();

        CreateMap<LoginUserDto, IdentityUser<Guid>>();
    }
}