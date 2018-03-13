using Bagaround.Entity;
using Bagaround.Models;
using System.Collections.Generic;
using System.Linq;

namespace Bagaround.Repository
{
    public class ProductRepository
    {
        public List<ProductType> GetProductType()
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var eachProduct = db.TypeProduct.Select(x => new ProductType
                {
                    ProductTypeId = x.TypeId,
                    ProductTypeName = x.TypeName
                }).ToList();

                return eachProduct;
            }
        }

        public List<BrandType> GetProductBrand()
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var productBrand = db.BrandProduct.Select(x => new BrandType
                {
                    BrandId = x.BrandId,
                    BrandName = x.BrandName
                }).ToList();
                return productBrand;
            }
        }

        public ProductItemInfo GetInfoProduct(int bagId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var itemInfo = db.Product.Where(x => x.BagId == bagId).Select(x => new ProductItemInfo
                {
                    ProductId = x.BagId,
                    ProductName = x.BagName,
                    Description = x.Description,
                    Price = x.Price,
                    Available = x.Available,
                    Stock = x.Stock
                }).SingleOrDefault();

                return itemInfo;
            }
        }

        public void EditProductInformation(HomeListItem editProductData)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var product = db.Product
                    .SingleOrDefault(x => x.BagId == editProductData.ProductItemInfo.ProductId);

                product.BagId = editProductData.ProductItemInfo.ProductId;
                product.BagName = editProductData.ProductItemInfo.ProductName;
                product.Price = editProductData.ProductItemInfo.Price;
                product.Description = editProductData.ProductItemInfo.Description;
                product.Available = editProductData.ProductItemInfo.Available;
                product.TypeId = editProductData.SelectedProductType;
                product.BrandId = editProductData.SelectedBrandType;
                product.Stock = editProductData.ProductItemInfo.Stock;
                db.SaveChanges();
            }
        }

        public void AddNewProduct(HomeListItem editProductData)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var product = new Product()
                {
                    BagName = editProductData.ProductItemInfo.ProductName,
                    BrandId = editProductData.SelectedBrandType,
                    TypeId = editProductData.SelectedProductType,
                    Price = editProductData.ProductItemInfo.Price,
                    Description = editProductData.ProductItemInfo.Description,
                    Available = editProductData.ProductItemInfo.Available,
                    Stock = editProductData.ProductItemInfo.Stock
                };
                db.Product.Add(product);
                db.SaveChanges();
            }
        }

        public void DeleteProductInStock(List<CartModel> productCart)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                foreach (var item in productCart)
                {
                    var stock = db.Product.Where(x => x.BagName == item.ProductName).Select(x => x.Stock).FirstOrDefault();
                    stock -= item.Quantity;
                    db.SaveChanges();
                }
            }
        }
    }
}