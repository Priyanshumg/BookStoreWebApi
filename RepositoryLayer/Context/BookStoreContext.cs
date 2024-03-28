using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Context
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<UserEntity> usersTable { get; set; }
        public DbSet<BooksEntity> BookTable { get; set; }
        public DbSet<FeedBackEntity> FeedbackTable { get; set; }
        public DbSet<MyCartEntity> MyCartTable { get; set; }

    }
}
