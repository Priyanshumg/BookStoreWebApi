using Microsoft.IdentityModel.Tokens;
using RepositoryLayer.Context;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Services
{
    public class MycartRepository : IMyCartInterface
    {
        private readonly BookStoreContext context;
        public MycartRepository(BookStoreContext context)
        {
            this.context = context;
        }


    }
}
