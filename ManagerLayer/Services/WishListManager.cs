using ManagerLayer.Interface;
using RepositoryLayer.Entity;
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
        public MyWishListEntity AddToWishList(int UserId, int BookId)
        {
            return repository.AddToWishList(UserId, BookId);
        }

        public List<MyWishListEntity> GetAllWishListNotes(int UserId)
        {
            return repository.GetAllWishListNotes(UserId);
        }

        public MyWishListEntity RemoveFromWishList(int UserId, int BookId)
        {
            return repository.RemoveFromWishList(UserId, BookId);
        }

    }
}
