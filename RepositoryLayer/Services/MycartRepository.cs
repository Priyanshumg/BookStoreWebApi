using CommonLayer.RequestModels.BookStore;
using CommonLayer.RequestModels.MyCart;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class MycartRepository : IMyCartInterface
    {
        private readonly BookStoreContext context;
        public MycartRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public MyCartEntity AddToCart(AddToCartModel model, int UserId)
        {
            var User = context.usersTable.FirstOrDefault(user => (user.UserId == UserId));
            if (User != null) // Meaning User Exist in usersTable
            {
                var book = context.BookTable.FirstOrDefault(book => book.BookId == model.BookId);
                if (book != null) // meaning BookExist in BookTable
                {
                    MyCartEntity AddBook = new MyCartEntity();
                    if (book.BookQuantity < model.Quantity)
                    {
                        throw new Exception($"We are little less on books availableBooks = {book.BookQuantity}");
                    }
                    else
                    {
                        AddBook.BookId = model.BookId;
                        AddBook.Quantity = model.Quantity;
                        AddBook.UserId = UserId;
                        context.Add(AddBook);
                        context.SaveChanges();
                        return AddBook;
                    }
                }
                else
                {
                    throw new Exception("Book Dosent exist");
                }
            }
            else
            {
                throw new Exception("User Dosent Exist");
            }
        }
    }
}
