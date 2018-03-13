using Bagaround.Filter;
using Bagaround.IPageList;
using Bagaround.Models;
using Bagaround.Repository;
using System.IO;
using System.Web.Mvc;

namespace Bagaround.Controllers
{
    public class BagShopController : Controller
    {
        private readonly UserRepository userRepository = new UserRepository();
        private readonly ProductRepository productRepository = new ProductRepository();
        private readonly PictureRepository pictureRepository = new PictureRepository();
        private readonly HistoryRepository historyRepository = new HistoryRepository();
        private readonly CartRepository cartRepository = new CartRepository();
        private readonly PageList pageList = new PageList();
        // GET: BagShop

        public ActionResult Home(int? page)
        {
            HomeListItem model = new HomeListItem();

            var allPicture = pictureRepository.GetAllPicture();

            var productsInOnePage = pageList.Image(allPicture, page);

            ViewBag.ProductsInOnePage = productsInOnePage;

            if (SessionMenager.UserId != null && cartRepository.CheckOutCart(int.Parse(SessionMenager.UserId)) == true)
            {
                var userId = int.Parse(SessionMenager.UserId);

                var cartId = cartRepository.SelectCart(userId);

                Session["cartIdSession"] = cartId;

                model.CartModel = cartRepository.SelectProductInCart(cartId);

                Session["ItemInCart"] = model.CartModel.Count;
            }

            model.PhototList = allPicture;

            return View(model);
        }

        public ActionResult ProductInfo(int bagId)
        {
            HomeListItem model = new HomeListItem();

            var allImageOfEachProduct = pictureRepository.GetAllOfSelectedPicture(bagId);

            model.PhototList = allImageOfEachProduct;

            ViewData["overQuantity"] = false;

            var infoProduct = productRepository.GetInfoProduct(bagId);

            model.ProductItemInfo = infoProduct;

            Session["ItemInCart"] = model.CartModel.Count;

            return View(model);
        }

        [RequireLogin]
        public ActionResult UserInfo()
        {
            var user = userRepository.GetUser(SessionMenager.Username);
            var his = historyRepository.HistoryUserPayment(int.Parse(SessionMenager.UserId));
            var model = new RegisterViewModel()
            {
                UserId = user.UserId,
                Username = user.Username,
                Name = user.Name,
                LastName = user.LastName,
                CreditCard = user.CreditCard,
                Address = user.Address,
                Role = user.Role,
                Description = user.Description,
                HistoryPayment = his
            };

            return View(model);
        }

        [RequireLogin]
        [HttpPost]
        public ActionResult EditUserData(RegisterViewModel editUser)
        {
            userRepository.SaveUser(editUser);
            return RedirectToAction("UserInfo", "BagShop");
        }
        [RequireAdmin]
        public ActionResult EditProductInfo(int bagId)
        {
            HomeListItem model = new HomeListItem();
            var infoProduct = productRepository.GetInfoProduct(bagId);

            model.ProductItemInfo = new ProductItemInfo()
            {
                ProductId = infoProduct.ProductId,
                ProductName = infoProduct.ProductName,
                Price = infoProduct.Price,
                Description = infoProduct.Description,
                Available = infoProduct.Available,
                Stock = infoProduct.Stock
                
            };
            return View(model);
        }
        [RequireAdmin]
        [HttpPost]
        public ActionResult EditProductInfo(HomeListItem editProductData)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Photo"), fileName);
                    file.SaveAs(path);
                    pictureRepository.AddNewPhotoProduct(fileName, editProductData.ProductItemInfo.ProductId);
                }
            }
            productRepository.EditProductInformation(editProductData);
            return RedirectToAction("ProductInfo", "BagShop", new { bagId = editProductData.ProductItemInfo.ProductId });
        }
        [RequireAdmin]
        public ActionResult AddNewProduct()
        {
            HomeListItem model = new HomeListItem();
            return View(model);
        }
        [RequireAdmin]
        [HttpPost]
        public ActionResult AddNewProduct(HomeListItem editProductData)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Photo"), fileName);
                    file.SaveAs(path);
                    productRepository.AddNewProduct(editProductData);
                    pictureRepository.UploadPhotoProduct(fileName);
                }
            }
            return RedirectToAction("Home", "BagShop");
        }

    }
}