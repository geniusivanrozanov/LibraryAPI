using LibraryAPI.BLL.Constants;
using LibraryAPI.BLL.DTOs.Author;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;


        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets the list of all authors")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            return Ok(authors);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets an author by id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            return Ok(author);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Creates new author")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(409)]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDto authorDto)
        {
            var createdAuthor = await _authorService.CreateAuthorAsync(authorDto);

            return CreatedAtAction(nameof(GetById), new { Id = createdAuthor.Id }, createdAuthor);
        }
        
        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Updates author with requested id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [SwaggerResponse(409)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto authorDto)
        {
            var updatedAuthor = await _authorService.UpdateAuthorAsync(id, authorDto);

            return Ok(updatedAuthor);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Deletes author with requested id")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _authorService.DeleteAuthorAsync(id);

            return NoContent();
        }
    }
}
