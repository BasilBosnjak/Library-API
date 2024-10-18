using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library_API.Dtos.Book;
using Library_API.Models;

namespace Library_API.Mappers
{
    public static class BookMappers
    {
        public static BookDto ToBookDto(this Book bookModel)
        {
            return new BookDto
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Author = bookModel.Author,
                Genre = bookModel.Genre,
                Year = bookModel.Year
            };
        }

        public static Book ToBookFromCreateDTO(this CreateBookRequestDto bookDto)
        {
            return new Book
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                Genre = bookDto.Genre,
                Year = bookDto.Year
            };
        }
    }
}