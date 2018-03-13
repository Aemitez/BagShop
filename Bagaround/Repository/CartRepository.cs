using Bagaround.Entity;
using Bagaround.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bagaround.Repository
{
    public class CartRepository
    {
        public void AddProductToCartUser(int productId, int productQuantity, int cartId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                if (db.ProductInCart.Any(x => x.CartId == cartId && x.BagId == productId))
                {
                    var productInCart = db.ProductInCart
                                          .Where(x => x.CartId == cartId && x.BagId == productId)
                                          .ToList();
                    foreach (var item in productInCart)
                    {
                        item.Quantity += productQuantity;
                    }
                    db.SaveChanges();
                }
                else
                {
                    var productInCart = new ProductInCart
                    {
                        BagId = productId,
                        Price = db.Product.Where(x => x.BagId == productId).Select(x => x.Price).SingleOrDefault(),
                        Quantity = productQuantity,
                        DateDelivery = DateTime.Now.AddDays(3),
                        CartId = cartId
                    };
                    db.ProductInCart.Add(productInCart);
                    db.SaveChanges();
                }


            }
        }

        public int SelectCart(int userId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                if (db.Cart.Any(x => x.UserId == userId && x.Checkout == false && x.Delivered == false))
                {
                    db.SaveChanges();
                }
                else
                {
                    var createCart = new Cart
                    {
                        UserId = userId,
                        Checkout = false,
                        Delivered = false,
                        TotalPrice = 0
                    };

                    db.Cart.Add(createCart);
                    db.SaveChanges();
                }
                var selectCart = db.Cart.Where(x => x.UserId == userId && x.Checkout == false && x.Delivered == false )
                                        .Select(x => x.CartId).SingleOrDefault();

                return selectCart;
            }
        }

        public List<CartModel> SelectProductInCart(int cartId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var listSelectProduct = db.ProductInCart
                                          .Where(x => x.CartId == cartId && x.Product.Available == true)
                                          .Select(x => new CartModel
                                          {
                                              CartId = cartId,
                                              Slip = x.Cart.Slip,
                                              ProductInCartId = x.PaymentId,
                                              ProductId = x.BagId,
                                              Quantity = x.Quantity,
                                              ProductName = x.Product.BagName,
                                              ProductPrice = x.Product.Price,
                                              ProductImage = x.Product.Picture.Select(picName => picName.PictureName).FirstOrDefault()
                                          }).ToList();

                return listSelectProduct;
            }
        }

        public bool CheckOutCart(int userId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var cartStatus = db.Cart.Any(x => x.UserId == userId && x.Checkout == false);

                return cartStatus;
            }
        }

        public void DeleteInCart(int productInCartId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var delete = db.ProductInCart.Find(productInCartId);

                db.ProductInCart.Remove(delete);
                db.SaveChanges();
            }
        }

        public List<Order> SelectOrder()
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var listOrder = db.Cart
                    .Where(x => x.ProductInCart.Select(carId => carId.PaymentId).ToList().Count != 0 && x.Slip != null)
                    .Select(x => new Order
                    {
                        OrderId = x.CartId,
                        OwnerName = x.User.Name,
                        CheckOut = x.Checkout,
                        Delivery = x.Delivered,
                        ProductName = x.ProductInCart.Select(bag => bag.Product.BagName).ToList(),
                        OwnerAddress = x.User.Address,
                        Quantity = x.ProductInCart.Select(quan => quan.Quantity).ToList(),
                        Slip = x.Slip,
                        TotalPrice = x.TotalPrice

                    }
                    ).OrderBy(x => x.CheckOut && x.Delivery).ToList();

                return listOrder;
            }
        }

        public void SentProduct(int orderId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var statusSent = db.Cart
                    .Where(x => x.CartId == orderId)
                    .ToList();
                foreach (var item in statusSent)
                {
                    item.Delivered = true;
                }
                db.SaveChanges();
            }
        }

        public void CheckoutProduct(int orderId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var statusDelivery = db.Cart
                    .FirstOrDefault(x => x.CartId == orderId);

                statusDelivery.Checkout = true;
                db.SaveChanges();
            }
        }
    }
}