using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RepositoryLayer.Entity
{
    public class MyCartEntity
    {
        [Key]
        public int CartId { get; set; }

        [ForeignKey("BookTable")]
        public int BookId { get; set; }

        // Navigation Property for BookTable
        public BooksEntity BookTable { get; set; }

        [ForeignKey("UserTable")]
        public int UserId { get; set; }

        // Navigation Property for UserTable
        public UserEntity UserTable { get; set; }

        public int Quantity { get; set; }
    }
}
