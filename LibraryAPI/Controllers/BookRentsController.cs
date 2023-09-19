using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryAPI.BLL.Constants;
using LibraryAPI.BLL.DTOs.BookRent;
using LibraryAPI.BLL.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetAll()
        {
            var bookRents = await _bookRentService.GetAllBookRentsAsync();

            return Ok(bookRents);
        }
        
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var bookRent = await _bookRentService.GetBookRentByIdAsync(id);

            return Ok(bookRent);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateBookRentDto bookRentDto)
        {
            var createdBookRent = await _bookRentService.CreateBookRentAsync(bookRentDto);

            return CreatedAtAction(nameof(GetById), new { Id = createdBookRent.Id }, createdBookRent);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateBookRentDto bookRentDto)
        {
            var updatedBookRent = await _bookRentService.UpdateBookRentAsync(id, bookRentDto);

            return Ok(updatedBookRent);
        }
        
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookRentService.DeleteBookRentAsync(id);

            return NoContent();
        }
    }
}
