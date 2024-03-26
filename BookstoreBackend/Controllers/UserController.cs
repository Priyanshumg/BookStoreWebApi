using CommonLayer.RequestModels;
using CommonLayer.ResponseModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;

namespace BookstoreBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserManager userManager;
        public UserController(IUserManager userManager)
        {
            this.userManager = userManager;
        }


        [HttpPost]
        [Route("RegisterUser")]
        public ActionResult UserRegistration(RegisterModel Model)
        {
            var response = userManager.UserRegistration(Model);
            if ( response != null )
            {
                return Ok(new ResponseModel<UserEntity>
                {
                    success = true,
                    Message = "Account Created",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<UserEntity>
                {
                    success = false,
                    Message = "Failed To Create Account",
                    Data = response
                });
            }
        }

    }
}
