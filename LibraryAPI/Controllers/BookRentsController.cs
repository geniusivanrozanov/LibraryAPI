using LibraryAPI.BLL.Constants;
using LibraryAPI.BLL.DTOs.BookRent;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookRentsController : ControllerBase
    {
        private readonly IBookRentService _bookRentService;
        
        public BookRentsController(IBookRentService bookRentService)
        {
            _bookRentService = bookRentService;
        }

        [HttpGet]
        [Authorize(Roles = Roles.Admin)]
        [HttpGet]
        [SwaggerOperation(Summary = "Gets the list of all rents")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        public async Task<IActionResult> GetAll()
        {
            var bookRents = await _bookRentService.GetAllBookRentsAsync();

            return Ok(bookRents);
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Gets a rent by id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var bookRent = await _bookRentService.GetBookRentByIdAsync(id);

            return Ok(bookRent);
        }

        [HttpPost]
        [Authorize]
        [SwaggerOperation(Summary = "Creates new rent")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        public async Task<IActionResult> Create([FromBody] CreateBookRentDto bookRentDto)
        {
            var createdBookRent = await _bookRentService.CreateBookRentAsync(bookRentDto);

            return CreatedAtAction(nameof(GetById), new { Id = createdBookRent.Id }, createdBookRent);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Updates rent with requested id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookRentDto bookRentDto)
        {
            var updatedBookRent = await _bookRentService.UpdateBookRentAsync(id, bookRentDto);

            return Ok(updatedBookRent);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Deletes rent with requested id")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookRentService.DeleteBookRentAsync(id);

            return NoContent();
        }
    }
}
