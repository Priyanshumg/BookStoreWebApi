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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CartId { get; set; }

        [ForeignKey("BookTable")]
        public int BookId { get; set; }

        // Navigation Property for BookID in Feedback
        public BooksEntity BookTable { get; set; }

        [ForeignKey("UserTable")]
        public int UserId { get; set; }

        // Navigation Property for BookID in Feedback
        public UserEntity UserTable { get; set; }

        public int Quantity { get; set; }
    }
}
