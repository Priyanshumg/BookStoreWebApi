using CommonLayer.RequestModels.BookStore;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class BookManager : IBookManager
    {
        private readonly IBookInterface repository;
        public BookManager(IBookInterface repository)
        {
            this.repository = repository;
        }

        public BooksEntity AddBook(AddBookModel model)
        {
            return repository.AddBook(model);
        }

        public List<BooksEntity> GetAllBook()
        {
            return repository.GetAllBook();
        }
    }
}
