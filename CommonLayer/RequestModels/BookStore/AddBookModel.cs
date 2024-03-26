using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace CommonLayer.RequestModels.BookStore
{
    public class AddBookModel
    {
        public string BookName { get; set; }

        public string BookAuthor { get; set; }

        public int AverageRatings { get; set; }

        public int Price { get; set; }

        public int DiscountedPrice { get; set; }

        public string BookDescription { get; set; }

        public string BookImage { get; set; }
        public int BookQuantity { get; set; }
    }
}
