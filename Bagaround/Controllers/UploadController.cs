using Bagaround.Models;
using Bagaround.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bagaround.Controllers
{
    public class UploadController : Controller
    {
        private readonly ProductRepository productRepository = new ProductRepository();
        private readonly PictureRepository pictureRepository = new PictureRepository();
        [HttpPost]
        public ActionResult Upload(decimal totalPrice)
        {
            var cartId = int.Parse(Session["cartIdSession"].ToString());
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Paymentslip"), fileName);
                    file.SaveAs(path);
                    pictureRepository.UploadSlipPicture(fileName,cartId,totalPrice);
                }
            }
            return RedirectToAction("Home","BagShop");
        }
    }
}