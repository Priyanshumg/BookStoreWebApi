using CommonLayer.RequestModels.UserAuth;
using CommonLayer.ResponseModel;
using ManagerLayer.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using RepositoryLayer.Entity;
using System.Runtime.InteropServices.WindowsRuntime;

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

        [HttpPost]
        [Route("Login")]
        public ActionResult Login(LoginModel model)
        {
            var response = userManager.UserLogin(model);
            if (response != null) 
            {
                return Ok(new ResponseModel<string>
                {
                    success = true,
                    Message = "Account Created",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<string>
                {
                    success = false,
                    Message = "Failed to Login",
                    Data = response
                });
            }
        }
        [HttpPost]
        [Route("ForgetPassword")]
        public ActionResult ForgetPassword(string Email)
        {
            var response = userManager.ForgetPassword(Email);
            if (response != null)
            {
                return Ok(new ResponseModel<ForgetPasswordModel>
                {
                    success = true,
                    Message = "Token Sent",
                    Data = response
                });
            }
            else
            {
                return BadRequest(new ResponseModel<ForgetPasswordModel>
                {
                    success = false,
                    Message = "Email Does not exist",
                    Data = response
                });
            }
        }

        [Authorize]
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult ResetPassword(ResetPasswordModel reset)
        {
            string Email = User.FindFirst("UserEmail").Value;
            if (userManager.ResetPassword(Email, reset))
            {
                return Ok(new ResponseModel<bool>
                {
                    success = true,
                    Message = "Password Reset",
                    Data = true
                }
                );
            }
            else
            {
                return BadRequest(new ResponseModel<bool>
                {
                    success = false,
                    Message = "Password cannot be reset",
                    Data = true
                });
            }
        }
    }
}
