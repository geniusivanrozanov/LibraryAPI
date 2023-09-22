using LibraryAPI.BLL.Constants;
using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;


        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        
        [HttpGet]
        [SwaggerOperation(Summary = "Gets the list of all books")]
        [SwaggerResponse(200)]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Gets a book by id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            return Ok(book);
        }
        
        [HttpGet("search")]
        [SwaggerOperation(Summary = "Gets a book with requested parameters")]
        [SwaggerResponse(200)]
        [SwaggerResponse(404)]
        public async Task<IActionResult> GetByISBN([FromQuery] string isbn)
        {
            var book = await _bookService.GetBookByIsbnAsync(isbn);

            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Creates new book")]
        [SwaggerResponse(201)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(409)]
        public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
        {
            var createdBook = await _bookService.CreateBookAsync(bookDto);

            return CreatedAtAction(nameof(GetById), new { Id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        [SwaggerOperation(Summary = "Updates book with requested id")]
        [SwaggerResponse(200)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [SwaggerResponse(409)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto bookDto)
        {
            var updatedBook = await _bookService.UpdateBookAsync(id, bookDto);

            return Ok(updatedBook);
        }
        
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deletes book with requested id")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookService.DeleteBookAsync(id);

            return NoContent();
        }

        [HttpPost("{id}/genres")]
        [SwaggerOperation(Summary = "Adds existing genre to the list of genres of requested book")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AddGenre(Guid id, [FromBody] Guid genreId)
        {
            await _bookService.AddBookGenreAsync(id, genreId);

            return NoContent();
        }
        
        [HttpDelete("{id}/genres/{genreId}")]
        [SwaggerOperation(Summary = "Removes existing genre from the list of genres of requested book")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> RemoveGenre(Guid id, Guid genreId)
        {
            await _bookService.RemoveBookGenreAsync(id, genreId);

            return NoContent();
        }
        
        [HttpPost("{id}/authors")]
        [SwaggerOperation(Summary = "Adds existing author to the list of authors of requested book")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> AddAuthor(Guid id, [FromBody] Guid authorId)
        {
            await _bookService.AddBookAuthorAsync(id, authorId);

            return NoContent();
        }
        
        [HttpDelete("{id}/authors/{authorId}")]
        [SwaggerOperation(Summary = "Removes existing author from the list of authors of requested book")]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [SwaggerResponse(403)]
        [SwaggerResponse(404)]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> RemoveAuthor(Guid id, Guid authorId)
        {
            await _bookService.RemoveBookAuthorAsync(id, authorId);

            return NoContent();
        }
    }
}