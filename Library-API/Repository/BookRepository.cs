using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_API.Interfaces;
using Library_API.Models;
using Library_API.Data;
using Microsoft.EntityFrameworkCore;
using Library_API.Dtos.Book;

// Interface

namespace Library_API.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDBContext _context;
        public BookRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<Book?> DeleteAsync(int id)
        {
            var bookModel = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (bookModel == null)
            {
                return null;
            }

            _context.Books.Remove(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book?> UpdateAsync(int id, UpdateBookRequestDto updateDto)
        {
            var existingBook = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            if (existingBook == null)
            {
                return null;
            }

            existingBook.Title = updateDto.Title;
            existingBook.Author = updateDto.Author;
            existingBook.Genre = updateDto.Genre;
            existingBook.Year = updateDto.Year;

            await _context.SaveChangesAsync();

            return existingBook;
        }
    }
}