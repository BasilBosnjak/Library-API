using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_API.Dtos.Book
{
    public class CreateBookRequestDto
    {
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;
        public int Year { get; set; }
    }
}