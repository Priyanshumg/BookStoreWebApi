﻿using CommonLayer.RequestModels.BookStore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IBookManager
    {
        public BooksEntity AddBook(AddBookModel model);

        public List<BooksEntity> GetAllBook();

        public BooksEntity GetBookByID(int Id);

        public List<BooksEntity> SortAndDisplayElementsInAscendingOrder();

        public List<BooksEntity> SortBooksByPriceDescending();

    }
}
