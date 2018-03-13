using Bagaround.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bagaround.Entity;
using Microsoft.Ajax.Utilities;

namespace Bagaround.Repository
{
    public class HistoryRepository
    {
        public List<HistoryPaymentModel> HistoryUserPayment(int userId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var history = db.ProductInCart
                                .Where(x => x.Cart.UserId == userId && x.Cart.Slip != null)
                                .Select(x => new HistoryPaymentModel
                                {
                                    CartId = x.Cart.CartId,
                                    ProductName = x.Product.BagName,
                                    Price = x.Price,
                                    ImageName = x.Product.Picture.Select(img => img.PictureName).FirstOrDefault(),
                                    Quantity = x.Quantity,
                                    ProductId = x.Product.BagId,
                                    Status = x.Cart.Delivered
                                    
                                }).OrderByDescending(x => x.CartId).ToList();
                return history;
            }
        }
    }
}