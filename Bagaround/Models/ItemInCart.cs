using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bagaround.Models
{
    public class ItemInCart
    {
        public List<int> ProductId { get; set; } = new List<int>();
        public List<int> ProductQuantity { get; set; } = new List<int>();
     
    }
}