using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bagaround.Models
{
    public class CartModel
    {
        public int CartId { get; set; }
        public int ProductInCartId { get; set; }
        public int ProductId { get; set; }
        public string ProductImage { get; set; }
        public int Quantity { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public string Slip { get; set; }
    }
}