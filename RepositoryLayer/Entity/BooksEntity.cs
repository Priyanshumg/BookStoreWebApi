using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class BooksEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        public string BookName { get; set; }

        [Required]
        public string BookAuthor { get; set; }

        [AllowNull]
        public int AverageRatings { get; set; }

        [Required]
        public int Price { get; set; }

        public int DiscountedPrice { get; set;}

        public string BookDescription { get; set; }

        public string BookImage { get; set; }

        [Required]
        public int BookQuantity { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
