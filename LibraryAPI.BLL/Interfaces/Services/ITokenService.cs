using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.BLL.Interfaces.Services;

public interface ITokenService
{
    Task<string> GenerateTokenAsync(IdentityUser<Guid> userEntity);
}