using CommonLayer.RequestModels.FeedBackModel;
using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace ManagerLayer.Interface
{
    public interface IFeedbackManager
    {
        public FeedBackEntity AddFeedback(AddFeedback model, int UserId);
    }
}