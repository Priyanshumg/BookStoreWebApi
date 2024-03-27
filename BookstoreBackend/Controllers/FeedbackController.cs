using CommonLayer.RequestModels.FeedBackModel;
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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackManager feedbackManager;
        public FeedbackController(IFeedbackManager feedbackManager)
        {
            this.feedbackManager = feedbackManager;
        }

        [HttpPost]
        [Authorize]
        [Route("AddFeedback")]
        public ActionResult AddFeedback(AddFeedback model)
        {
            int UserId = Convert.ToInt32(User.FindFirst("UserId").Value);
            var response = feedbackManager.AddFeedback(model, UserId);
            if (response != null)
            {
                return Ok(new ResponseModel<FeedBackEntity>
                {
                    success = true,
                    Message = "Feedback Added Successfully",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<FeedBackEntity>
                {
                    success = false,
                    Message = "Could not add feedback",
                    Data = response
                });
            }
        }
    }
}
