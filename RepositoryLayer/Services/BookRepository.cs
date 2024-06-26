﻿using CommonLayer.RequestModels.BookStore;
using Microsoft.AspNetCore.Server.IIS.Core;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
                newBook.CreatedAt = DateTime.Now;
                newBook.UpdatedAt = DateTime.Now;
                context.Add(newBook);
                context.SaveChanges();
                return newBook;
            }
            else
            {
                throw new Exception("Book Already Exist, Update Book or Delete Book");
            }
        }

        public List<BooksEntity> GetAllBook()
        {
            return context.BookTable.ToList();
        }

        public BooksEntity GetBookByID(int Id)
        {
            return context.BookTable.FirstOrDefault(book => book.BookId == Id);
        }

        public List<BooksEntity> SortAndDisplayElementsInAscendingOrder()
        {
            return context.BookTable.OrderBy(book => book.Price).ToList();
        }

        public List<BooksEntity> SortBooksByPriceDescending()
        {

            return context.BookTable.OrderByDescending(book => book.Price).ToList();
        }

        public List<BooksEntity> SortByRecentArrival()
        {
            return context.BookTable.OrderByDescending(book => book.CreatedAt).ToList();
        }

        public List<BooksEntity> SortByOlderFirstArrival()
        {
            return context.BookTable.OrderBy(book => book.CreatedAt).ToList();
        }

        public List<BooksEntity> Search(string query)
        {
            List<BooksEntity> Search = context.BookTable.Where(x => (x.BookName== query) || (x.BookAuthor == query)).ToList();
            if (Search.Count > 0)
            {
                return Search;
            }
            else
            {
                throw new Exception("No books Found");
            }

        }
    }
}
