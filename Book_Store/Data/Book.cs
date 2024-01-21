// Data/Book.cs
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Store.Data
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string? BookName { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string? Author { get; set; }

        public int? Length { get; set; }
        public string? Publisher { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public string? Language { get; set; }

        [Required(ErrorMessage = "{0} is required.")]
        public decimal? Price { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }

        public string? Image { get; set; }

        public int CategoryID { get; set; }

     
    }
}
