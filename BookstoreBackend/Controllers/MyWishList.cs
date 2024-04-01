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
    public class MyWishList : ControllerBase
    {
        private readonly IWishListManager manager;
        public MyWishList(IWishListManager manager)
        {
            this.manager = manager;
        }

        [Authorize]
        [HttpPost]
        [Route("AddToWishList")]
        public ActionResult AddToWishlist(int BookId)
        {
            try
            {
                int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
                var response = manager.AddToWishList(userId, BookId);
                if (response != null)
                {
                    return Ok(new ResponseModel<MyWishList> { Success = true, Message = "Added to WishList", Data = response });
                }
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = "Adding to WishList Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResModel<WishListEntity> { Success = false, Message = ex.Message });
            }
        }

    }
}
