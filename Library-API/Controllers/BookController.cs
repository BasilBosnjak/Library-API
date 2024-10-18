using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Library_API.Data;
using Library_API.Mappers;

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
    }
}