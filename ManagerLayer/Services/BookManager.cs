using CommonLayer.RequestModels.BookStore;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
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

        public BooksEntity GetBookByID(int Id)
        {
            return repository.GetBookByID(Id);
        }

        public List<BooksEntity> SortAndDisplayElementsInAscendingOrder()
        {
            return repository.SortAndDisplayElementsInAscendingOrder();
        }



    }
}
