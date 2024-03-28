using ManagerLayer.Interface;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagerLayer.Services
{
    public class MyCartManager : IMyCartManager
    {
        private readonly IMyCartInterface repository;
        public MyCartManager(IMyCartInterface repository)
        {
            this.repository = repository;
        }
    }
}
