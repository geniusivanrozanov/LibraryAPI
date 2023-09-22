using LibraryAPI.BLL.Constants;
using LibraryAPI.BLL.DTOs.Genre;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Gets the list of all genres")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _genreService.GetAllGenresAsync();

            return Ok(genres);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a genre by id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var genre = await _genreService.GetGenreByIdAsync(id);

            return Ok(genre);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Creates new genre")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(409)]
        public async Task<IActionResult> Create([FromBody] CreateGenreDto genreDto)
        {
            var createdGenre = await _genreService.CreateGenreAsync(genreDto);

            return CreatedAtAction(nameof(GetById), new { Id = createdGenre.Id }, createdGenre);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Updates genre with requested id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [SwaggerResponse(409)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateGenreDto genreDto)
        {
            var updatedGenre = await _genreService.UpdateGenreAsync(id, genreDto);

            return Ok(updatedGenre);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Deletes genre with requested id")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _genreService.DeleteGenreAsync(id);

            return NoContent();
        }
    }
}
