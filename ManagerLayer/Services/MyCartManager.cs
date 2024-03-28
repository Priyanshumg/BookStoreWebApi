using CommonLayer.RequestModels.MyCart;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class MyCartManager : IMyCartManager
    {
        private readonly IMyCartInterface repository;
        public MyCartManager(IMyCartInterface repository)
        {
            this.repository = repository;
        }

        public MyCartEntity AddToCart(AddToCartModel model, int UserId)
        {
            return repository.AddToCart(model, UserId);
        }
    }
}
