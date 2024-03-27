using CommonLayer.RequestModels.BookStore;
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
    }
}
