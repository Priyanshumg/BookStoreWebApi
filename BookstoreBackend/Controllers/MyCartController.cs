using CommonLayer.RequestModels.MyCart;
using CommonLayer.ResponseModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;

namespace BookstoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyCartController : ControllerBase
    {

        private readonly IMyCartManager myCartManager;
        public MyCartController(IMyCartManager myCartManager)
        {
            this.myCartManager = myCartManager;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToCart")]
        public ActionResult AddToCart(AddToCartModel model)
        {
            int UserId = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = myCartManager.AddToCart(model, UserId);
            if (response != null)
            {
                return Ok(new ResponseModel<MyCartEntity>
                {
                    success = true,
                    Message = "Book Added To cart Successfully",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<MyCartEntity>
                {
                    success = false,
                    Message = "Failed To Add into Cart",
                    Data = response
                });
            }
        }
    }
}
