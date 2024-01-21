// Data/BookCategory.cs
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Book_Store.Data
{
    public class BookCategory
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string? CategoryName { get; set; }

        
    }
}
