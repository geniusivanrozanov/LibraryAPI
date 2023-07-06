using LibraryAPI.BLL.DTOs.User;

namespace LibraryAPI.BLL.Interfaces.Services;

public interface IUserService
{
    Task<string> RegisterUserAsync(RegistrationUserDto registrationUserDto);

    Task<string> LoginUserAsync(LoginUserDto loginUserDto);
}