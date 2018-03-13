using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bagaround.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerAddress { get; set; }
        public List<string> ProductName { get; set; }
        public List<int> Quantity { get; set; }
        public bool CheckOut { get; set; }
        public decimal TotalPrice { get; set; }
        public bool Delivery { get; set; }
        public string Slip { get; set; }
    }
}