using CommonLayer.RequestModels;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IUserInterface
    {
        public UserEntity UserRegistration(RegisterModel model);
        public string UserLogin(LoginModel model);
    }
}
