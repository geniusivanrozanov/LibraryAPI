using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LibraryAPI.BLL.Services;

public class TokenService : ITokenService
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly string _secretCode;

    public TokenService(UserManager<IdentityUser<Guid>> userManager, 
        IConfiguration configuration)
    {
        _userManager = userManager;
        _secretCode = configuration["JwtConfig:Secret"];
    }
    
    public async Task<string> GenerateTokenAsync(IdentityUser<Guid> userEntity)
    {
        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var key = Encoding.UTF8.GetBytes(_secretCode);
        
        var roles = await _userManager.GetRolesAsync(userEntity);
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new []
            {
                new Claim(ClaimTypes.NameIdentifier, $"{userEntity.Id}"),
                new Claim(ClaimTypes.Role, $"{string.Join(", ", roles)}"),
                new Claim(ClaimTypes.Name, userEntity.UserName),
            }),
            Expires = DateTime.Now.AddMinutes(5),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(key), 
                SecurityAlgorithms.HmacSha256Signature
            ),
        };

        var token = jwtTokenHandler.CreateToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(token);
    }
}