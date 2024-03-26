using ManagerLayer.Interface;
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
    }
}
