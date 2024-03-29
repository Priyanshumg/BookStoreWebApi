using ManagerLayer.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ManagerLayer.Services
{
    public class WishListManager : IWishListManager
    {
        private readonly IWishListRepository repository;
        public WishListManager(IWishListRepository repository)
        {
            this.repository = repository;
        }
    }
}
