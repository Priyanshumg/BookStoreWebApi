using CommonLayer.RequestModels;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserInterface repository;
        public UserManager(IUserInterface repository)
        {
            this.repository = repository;   
        }

        public UserEntity UserRegistration(RegisterModel model)
        {
            return repository.UserRegistration(model);
        }
    }
}
