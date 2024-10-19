using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library_API.Data;
using Library_API.Mappers;
using Library_API.Dtos.Book;

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
        public IActionResult GetAll()
        {
            var books = _context.Books.ToList()
            .Select(s => s.ToBookDto());
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var book = _context.Books.Find(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book.ToBookDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateBookRequestDto bookDto)
        {
            var bookModel = bookDto.ToBookFromCreateDTO();
            _context.Books.Add(bookModel);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = bookModel.Id }, bookModel.ToBookDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateBookRequestDto updateDto)
        {
            var bookModel = _context.Books.FirstOrDefault(x => x.Id == id);

            if (bookModel == null)
            {
                return NotFound();
            }

            bookModel.Title = updateDto.Title;
            bookModel.Author = updateDto.Author;
            bookModel.Genre = updateDto.Genre;
            bookModel.Year = updateDto.Year;

            _context.SaveChanges();

            return Ok(bookModel.ToBookDto());
        }
    }
}