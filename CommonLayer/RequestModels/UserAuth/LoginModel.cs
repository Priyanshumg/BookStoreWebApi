using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModels.UserAuth
{
    public class LoginModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
