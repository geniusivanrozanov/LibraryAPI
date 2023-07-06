using AutoMapper;
using LibraryAPI.BLL.Constants;
using LibraryAPI.BLL.DTOs.User;
using LibraryAPI.BLL.Exceptions;
using LibraryAPI.BLL.Interfaces.Services;
using LibraryAPI.BLL.Interfaces.Validators;
using Microsoft.AspNetCore.Identity;

namespace LibraryAPI.BLL.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser<Guid>> _userManager;
    private readonly RoleManager<IdentityRole<Guid>> _roleManager;
    private readonly SignInManager<IdentityUser<Guid>> _signInManager;
    private readonly IValidatorManager _validatorManager;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;

    public UserService(UserManager<IdentityUser<Guid>> userManager, IValidatorManager validatorManager, IMapper mapper, ITokenService tokenService, RoleManager<IdentityRole<Guid>> roleManager, SignInManager<IdentityUser<Guid>> signInManager)
    {
        _userManager = userManager;
        _validatorManager = validatorManager;
        _mapper = mapper;
        _tokenService = tokenService;
        _roleManager = roleManager;
        _signInManager = signInManager;
    }

    public async Task<string> RegisterUserAsync(RegistrationUserDto registrationUserDto)
    {
        var validationResults = await _validatorManager.ValidateAsync(registrationUserDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        var userEntity = _mapper.Map<IdentityUser<Guid>>(registrationUserDto);
        var registrationResult = await _userManager.CreateAsync(userEntity, registrationUserDto.Password);
        if (!registrationResult.Succeeded)
        {
            throw new RegistrationFailedException(registrationResult.ToString());
        }
        
        await _userManager.AddToRoleAsync(userEntity, Roles.User);

        return await _tokenService.GenerateTokenAsync(userEntity);
    }

    public async Task<string> LoginUserAsync(LoginUserDto loginUserDto)
    {
        var validationResults = await _validatorManager.ValidateAsync(loginUserDto);
        if (!validationResults.IsValid)
        {
            throw new ValidationException(validationResults.ToString());
        }

        var userEntity = await _userManager.FindByNameAsync(loginUserDto.UserName);
        var loginResult = await _signInManager.CheckPasswordSignInAsync(userEntity, loginUserDto.Password, false);

        if (!loginResult.Succeeded)
        {
            throw new LoginFailedException(loginResult.ToString());
        }

        return await _tokenService.GenerateTokenAsync(userEntity);
    }
}