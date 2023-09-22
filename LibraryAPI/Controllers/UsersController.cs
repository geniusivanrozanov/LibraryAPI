using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.BLL.DTOs.User;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        [SwaggerOperation(Summary = "Registers new user")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(409)]
        public async Task<IActionResult> Register([FromBody] RegistrationUserDto registrationUserDto)
        {
            return Ok(await _userService.RegisterUserAsync(registrationUserDto));
        }
        
        [HttpPost("login")]
        [SwaggerOperation(Summary = "Logins user")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUserDto)
        {
            return Ok(await _userService.LoginUserAsync(loginUserDto));
        }
    }
}
