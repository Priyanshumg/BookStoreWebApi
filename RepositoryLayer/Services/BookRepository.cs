using CommonLayer.RequestModels.BookStore;
using Microsoft.AspNetCore.Server.IIS.Core;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRepository : IBookInterface
    {
        private readonly BookStoreContext context;
        public BookRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public BooksEntity AddBook(AddBookModel model)
        {
            var Book = context.BookTable.FirstOrDefault(book => book.BookName == model.BookName);
            if (Book == null)
            {
                BooksEntity newBook = new BooksEntity();
                newBook.BookName = model.BookName;
                newBook.BookAuthor = model.BookAuthor;
                newBook.AverageRatings = 0;
                newBook.Price = model.Price;
                newBook.DiscountedPrice = model.DiscountedPrice;
                newBook.BookDescription = model.BookDescription;
                newBook.BookImage = model.BookImage;
                newBook.BookQuantity = model.BookQuantity;
                context.Add(newBook);
                context.SaveChanges();
                return newBook;
            }
            else
            {
                throw new Exception("Book Already Exist, Update Book or Delete Book");
            }
        }

    }
}
