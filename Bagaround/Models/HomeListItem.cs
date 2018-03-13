using Bagaround.Repository;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Bagaround.Models
{
    public class HomeListItem
    {
        public int SelectedProductType { get; set; }
        public List<SelectListItem> ProductTypes { get; set; } = new List<SelectListItem>();
        public int SelectedBrandType { get; set; }
        public List<SelectListItem> BrandTypes { get; set; } = new List<SelectListItem>();
        public List<ProductType> ProductType { get; set; }
        public List<PhotoList> PhototList { get; set; } = new List<PhotoList>();
        public Search Search { get; set; } = new Search();
        public ProductItemInfo ProductItemInfo { get; set; } = new ProductItemInfo();
        public List<ItemInCart> ItemInCart { get; set; } = new List<ItemInCart>();
        public List<CartModel> CartModel { get; set; } = new List<Models.CartModel>();

        public HomeListItem()
        {
            ProductRepository productRepository = new ProductRepository();

            var productType = productRepository.GetProductType();

            ProductType = new List<Models.ProductType>();

            foreach (var item in productType)
            {
                ProductType.Add(new ProductType
                {
                    ProductTypeId = item.ProductTypeId,
                    ProductTypeName = item.ProductTypeName
                });
            }

            foreach (var item in productType)
            {
                ProductTypes.Add(new SelectListItem()
                {
                    Text = item.ProductTypeName,
                    Value = item.ProductTypeId.ToString()
                });
            }

            var productBrand = productRepository.GetProductBrand();

            foreach (var item in productBrand)      
            {
                BrandTypes.Add(new SelectListItem()
                {
                    Text = item.BrandName,
                    Value = item.BrandId.ToString()
                });
            }

        }
    }
}