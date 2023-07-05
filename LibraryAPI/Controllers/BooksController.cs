using LibraryAPI.BLL.DTOs.Book;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookService.GetAllBooksAsync();

            return Ok(books);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookDto bookDto)
        {
            var createdBook = await _bookService.CreateBookAsync(bookDto);

            return CreatedAtAction(nameof(GetById), new { Id = createdBook.Id }, createdBook);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookDto bookDto)
        {
            var updatedBook = await _bookService.UpdateBookAsync(id, bookDto);

            return Ok(updatedBook);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookService.DeleteBookAsync(id);

            return NoContent();
        }

        [HttpPost("{id}/genres")]
        public async Task<IActionResult> AddGenre(Guid id, [FromBody] Guid genreId)
        {
            await _bookService.AddBookGenreAsync(id, genreId);

            return NoContent();
        }
        
        [HttpDelete("{id}/genres/{genreId}")]
        public async Task<IActionResult> RemoveGenre(Guid id, Guid genreId)
        {
            await _bookService.RemoveBookGenreAsync(id, genreId);

            return NoContent();
        }
        
        [HttpPost("{id}/authors")]
        public async Task<IActionResult> AddAuthor(Guid id, [FromBody] Guid authorId)
        {
            await _bookService.AddBookAuthorAsync(id, authorId);

            return NoContent();
        }
        
        [HttpDelete("{id}/authors/{authorId}")]
        public async Task<IActionResult> RemoveAuthor(Guid id, Guid authorId)
        {
            await _bookService.RemoveBookAuthorAsync(id, authorId);

            return NoContent();
        }
    }
}