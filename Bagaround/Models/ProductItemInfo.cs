using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bagaround.Models
{
    public class ProductItemInfo
    {
        public int ProductId { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Username range of 5-100 character")]
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        [AllowHtml]
        public string Description { get; set; }
        public bool Available { get; set; }
        public int Quantity { get; set; }
        public int Stock { get; set; }
    }
}