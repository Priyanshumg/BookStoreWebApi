using CommonLayer.RequestModels.FeedBackModel;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface IFeedbackRepository
    {
        public FeedBackEntity AddFeedback(AddFeedback model, int UserId);
    }
}
