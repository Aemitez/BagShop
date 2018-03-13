using Bagaround.Models;
using System.Collections.Generic;
using X.PagedList;

namespace Bagaround.IPageList
{
    public class PageList
    {
        public IPagedList<PhotoList> Image(List<PhotoList> photoList, int? page)
        {
            var pageNumber = page ?? 1;
            var productsInOnePage = photoList.ToPagedList(pageNumber, 12);

            return productsInOnePage;
        }
    }
}