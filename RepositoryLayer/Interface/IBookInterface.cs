﻿using CommonLayer.RequestModels.BookStore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IBookInterface
    {
        public BooksEntity AddBook(AddBookModel model);

        public List<BooksEntity> GetAllBook();

        public BooksEntity GetBookByID(int Id);

        public List<BooksEntity> SortAndDisplayElementsInAscendingOrder();

        public List<BooksEntity> SortBooksByPriceDescending();

        public List<BooksEntity> SortByRecentArrival();
        public List<BooksEntity> SortByOlderFirstArrival();

        public List<BooksEntity> Search(string query);
    }
}
