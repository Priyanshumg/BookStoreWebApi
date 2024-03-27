using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.RequestModels.FeedBackModel
{
    public class AddFeedback
    {
        public int bookId {  get; set; }
        public float CustomerRatings { get; set; }
        public string CustomerFeedback { get; set; }
    }
}
