using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.RequestModels.UserAuth
{
    public class ForgetPasswordModel
    {
        public string Email { get; set; }
        public string token { get; set; }
    }
}
