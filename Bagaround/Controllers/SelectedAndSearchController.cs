using Bagaround.IPageList;
using Bagaround.Models;
using Bagaround.Repository;
using System.Web.Mvc;

namespace Bagaround.Controllers
{
    public class SelectedAndSearchController : Controller
    {
        private readonly PictureRepository pictureRepository = new PictureRepository();
        private readonly PageList pageList = new PageList();

        public ActionResult ShowProductSelectType(int? page)
        {
            var type = Session["sessionType"];

            HomeListItem model = new HomeListItem();

            var selectType = pictureRepository.GetPictureOfTypeSelected(int.Parse(type.ToString()));

            var productsInOnePage = pageList.Image(selectType, page);

            ViewBag.ProductsInOnePage = productsInOnePage;

            model.PhototList = selectType;

            return View(model);
        }

        public ActionResult ShowSearchResult(int? page)
        {
            HomeListItem model = new HomeListItem();

            var searchPic = pictureRepository.GetPictureBySearch(Session["sessionSearch"].ToString());

            var productsInOnePage = pageList.Image(searchPic, page);

            ViewBag.ProductsInOnePage = productsInOnePage;

            model.PhototList = searchPic;

            return View(model);
        }

        public ActionResult SetSessionType(int typeId)
        {
            Session["sessionType"] = typeId;
            return RedirectToAction("ShowProductSelectType");
        }

        [HttpPost]
        public ActionResult SetSessionSearch(HomeListItem searchKey)
        {
            string key = searchKey.Search.SearchKey;
            Session["sessionSearch"] = key;
            return RedirectToAction("ShowSearchResult");
        }
    }
}