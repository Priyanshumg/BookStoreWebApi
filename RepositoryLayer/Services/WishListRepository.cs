using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class WishListRepository : IWishListRepository
    {
        private readonly BookStoreContext context;
        public WishListRepository(BookStoreContext context)
        {
            this.context = context;
        }
    }
}
