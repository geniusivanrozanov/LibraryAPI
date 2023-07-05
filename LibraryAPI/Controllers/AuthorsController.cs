using LibraryAPI.BLL.DTOs.Author;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorService.GetAllAuthorsAsync();

            return Ok(authors);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAuthorDto authorDto)
        {
            var createdAuthor = await _authorService.CreateAuthorAsync(authorDto);

            return CreatedAtAction(nameof(GetById), new { Id = createdAuthor.Id }, createdAuthor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateAuthorDto authorDto)
        {
            var updatedAuthor = await _authorService.UpdateAuthorAsync(id, authorDto);

            return Ok(updatedAuthor);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _authorService.DeleteAuthorAsync(id);

            return NoContent();
        }
    }
}
