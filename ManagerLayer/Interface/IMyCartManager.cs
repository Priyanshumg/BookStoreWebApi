using CommonLayer.RequestModels.MyCart;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IMyCartManager
    {
        public MyCartEntity AddToCart(AddToCartModel model, int UserId);

        public MyCartEntity RemoveFromCart(int BookId, int UserId);
    }
}
