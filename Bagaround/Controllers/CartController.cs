using Bagaround.Filter;
using Bagaround.Models;
using Bagaround.Repository;
using System.Web.Mvc;

namespace Bagaround.Controllers
{
    
    public class CartController : Controller
    {
        private readonly CartRepository cartRepository = new CartRepository();

        public ActionResult Index()
        {
            HomeListItem model = new HomeListItem();

            if (SessionMenager.UserId != null && cartRepository.CheckOutCart(int.Parse(SessionMenager.UserId)) == true)
            {
                var userId = int.Parse(SessionMenager.UserId);

                var cartId = cartRepository.SelectCart(userId);

                Session["cartIdSession"] = cartId;

                model.CartModel = cartRepository.SelectProductInCart(cartId);

                Session["ItemInCart"] = model.CartModel.Count;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult AddCart(int id, string quantity)
        {
            var userId = int.Parse(SessionMenager.UserId);

            var cartId = cartRepository.SelectCart(userId);

            cartRepository.AddProductToCartUser(id, int.Parse(quantity), cartId);

            return RedirectToAction("ProductInfo", id);
        }

        [RequireAdmin]
        public ActionResult Order()
        {
            var listOrder = cartRepository.SelectOrder();
            return View(listOrder);
        }

        public ActionResult DeleteInCart(int productInCartId)
        {
            cartRepository.DeleteInCart(productInCartId);

            var itemIncart = int.Parse(Session["ItemInCart"].ToString());
            itemIncart -= 1;
            Session["ItemInCart"] = itemIncart;

            return RedirectToAction("Index");
        }
        [RequireAdmin]
        public ActionResult SentProduct(int orderId)
        {
            cartRepository.SentProduct(orderId);
            return RedirectToAction("Order");
        }
        [RequireAdmin]
        public ActionResult CheckoutProduct(int orderId)
        {
            cartRepository.CheckoutProduct(orderId);
            return RedirectToAction("Order");
        }
    }
}