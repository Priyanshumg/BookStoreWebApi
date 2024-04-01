using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IWishListManager
    {
        public MyWishListEntity AddToWishList(int UserId, int BookId);
    }
}
