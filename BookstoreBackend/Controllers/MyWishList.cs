using CommonLayer.ResponseModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;

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
                    return Ok(new ResponseModel<MyWishListEntity> { success = true, Message = "Added to WishList", Data = response });
                }
                return BadRequest(new ResponseModel<MyWishListEntity> { success = false, Message = "Adding to WishList Failed", Data = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<MyWishListEntity> { success = false, Message = ex.Message });
            }
        }

        [Authorize]
        [HttpGet]
        [Route("GetAllWishListBooks")]
        public ActionResult GetAllWishListBook()
        {
            int userId = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = manager.GetAllWishListNotes(userId);
            if (response != null)
            {
                return Ok(new ResponseModel<List<MyWishListEntity>> { success = true, Message = "Fetched All notes successfully", Data = response });
            }
            return BadRequest(new ResponseModel<List<MyWishListEntity>> { success = false, Message = "Fetching of notes failed", Data = null });
        }


    }
}
