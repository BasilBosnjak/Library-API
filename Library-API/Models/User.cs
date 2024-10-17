using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library_API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;

        // Foreign key property
        public int? BookId { get; set; }

        // Navigation property
        public Book? RentedBook { get; set; }
    }
}