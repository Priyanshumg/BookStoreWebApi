using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public MyWishListEntity AddToWishList(int UserId, int BookId)
        {
            var existingbook = context.WishListTable.FirstOrDefault(x => x.UserId == UserId && x.BookId == BookId);
            if (existingbook == null)
            {
                MyWishListEntity newbook = new MyWishListEntity();
                newbook.UserId = UserId;
                newbook.BookId = BookId;
                context.WishListTable.Add(newbook);
                context.SaveChanges();
                return newbook;
            }
            throw new Exception("Book Already exist in the wishList");
        }

        public List<MyWishListEntity> GetAllWishListNotes(int UserId)
        {
            List<MyWishListEntity> wishlist = context.WishListTable.Where(x => x.UserId == UserId).ToList();
            return wishlist;
        }

        public MyWishListEntity RemoveFromWishList(int UserId, int BookId)
        {
            var existingbook = context.WishListTable.FirstOrDefault(x => x.UserId == UserId && x.BookId == BookId);
            if (existingbook != null)
            {
                context.WishListTable.Remove(existingbook);
                context.SaveChanges();
                return existingbook;
            }
            throw new Exception("Book doesnot present in the wishList");
        }
    }
}
