using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library_API.Data;
using Library_API.Mappers;
using Library_API.Dtos.Book;
using Microsoft.EntityFrameworkCore;

namespace Library_API.Controllers
{
    [Route("Library-API/book")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public BookController(ApplicationDBContext context)
        {
            _context = context;  
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _context.Books.ToListAsync();
            var bookDto = books.Select(s => s.ToBookDto());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookRequestDto bookDto)
        {
            var bookModel = bookDto.ToBookFromCreateDTO();
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = bookModel.Id }, bookModel.ToBookDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBookRequestDto updateDto)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (bookModel == null)
            {
                return NotFound();
            }

            bookModel.Title = updateDto.Title;
            bookModel.Author = updateDto.Author;
            bookModel.Genre = updateDto.Genre;
            bookModel.Year = updateDto.Year;

            await _context.SaveChangesAsync();

            return Ok(bookModel.ToBookDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var bookModel = _context.Books.FirstOrDefault(x => x.Id == id);

            if (bookModel == null)
            {
                return NotFound();
            }

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}