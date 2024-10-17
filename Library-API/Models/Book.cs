using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_API.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;
        public int Year { get; set; }

        // Foreign key property
        public int? UserId { get; set; }
        // Navigation property
        public User? User { get; set; }
    }
}