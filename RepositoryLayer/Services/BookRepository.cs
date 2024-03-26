using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class BookRepository : IBookInterface
    {
        private readonly BookStoreContext context;
    }
}
