using System;
using System.Collections.Generic;
using System.Text;
using CommonLayer.RequestModels.FeedBackModel;
using ManagerLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;

namespace ManagerLayer.Services
{
    public class FeedbackManager : IFeedbackManager
    {
        private readonly IFeedbackRepository repository;
        public FeedbackManager(IFeedbackRepository repository)
        {
            this.repository = repository;
        }
        public FeedBackEntity AddFeedback(AddFeedback model, int UserId)
        {
            return repository.AddFeedback(model, UserId);
        }
        public List<FeedBackEntity> GetFeedBackByBookId(int Id)
        {
            return repository.GetFeedBackByBookId(Id);
        }
    }
}
