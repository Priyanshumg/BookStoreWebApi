using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IWishListRepository
    {
        public MyWishListEntity AddToWishList(int UserId, int BookId);
    }
}
