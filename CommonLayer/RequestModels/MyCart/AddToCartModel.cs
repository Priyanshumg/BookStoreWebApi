using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.RequestModels.MyCart
{
    public class AddToCartModel
    {
        public int BookId { get; set; }
        public int Quantity { get; set; }
    }
}
