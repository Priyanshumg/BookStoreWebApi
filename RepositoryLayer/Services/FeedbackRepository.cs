using CommonLayer.RequestModels.FeedBackModel;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly BookStoreContext context;
        public FeedbackRepository(BookStoreContext context)
        {
            this.context = context;
        }

        public FeedBackEntity AddFeedback(AddFeedback model,int UserId)
        {
            var book = context.BookTable.FirstOrDefault(book => book.BookId == model.bookId);
            if (book != null)
            {
                FeedBackEntity newFeedback = new FeedBackEntity();
                newFeedback.BookId = model.bookId;
                newFeedback.UserId = UserId;
                newFeedback.CustomerFeedback = model.CustomerFeedback;
                newFeedback.CustomerRatings = model.CustomerRatings;
                context.Add(newFeedback);
                context.SaveChanges();
                return newFeedback;
            }
            else
            {
                throw new Exception("Book Not Found");
            }
        }

        public List<FeedBackEntity> GetFeedBackByBookId(int Id)
        {
            return context.FeedbackTable.Where(feedback => feedback.BookId == Id).ToList();
        }
    }
}
