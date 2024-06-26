﻿using CommonLayer.RequestModels.UserAuth;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Interface
{
    public interface IUserManager
    {
        public UserEntity UserRegistration(RegisterModel model);
        public string UserLogin(LoginModel model);
        public ForgetPasswordModel ForgetPassword(string UserEmail);

        public bool ResetPassword(string Email, ResetPasswordModel model);
    }
}