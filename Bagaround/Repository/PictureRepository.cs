using Bagaround.Entity;
using Bagaround.Models;
using Microsoft.Ajax.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Bagaround.Repository
{
    public class PictureRepository
    {
        public List<PhotoList> GetAllPicture()
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var photoListAll = db.Picture.Select(x => new PhotoList
                {
                    PictureId = x.PictureId,
                    PictureName = x.PictureName,
                    ProductBagName = x.Product.BagName,
                    ProductBagId = x.BagId
                }).DistinctBy(x => x.ProductBagId).ToList();

                return photoListAll;
            }
        }

        public List<PhotoList> GetPictureOfTypeSelected(int typeId)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var selectedTypePicture = db.Picture.Where(x => x.Product.TypeId == typeId)
                                                    .Select(x => new PhotoList
                                                    {
                                                        PictureId = x.PictureId,
                                                        PictureName = x.PictureName,
                                                        ProductBagId = x.BagId,
                                                        ProductBagName = x.Product.BagName
                                                    }).DistinctBy(x => x.ProductBagId).ToList();

                return selectedTypePicture;
            }
        }

        public List<PhotoList> GetPictureBySearch(string searchKey)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var searchForPicture = db.Picture.Where(x => x.Product.BagName.ToLower().Contains(searchKey.ToLower()) || x.Product.BrandProduct.BrandName.ToLower().Contains(searchKey.ToLower()) || x.Product.TypeProduct.TypeName.ToLower().Contains(searchKey.ToLower()))
                                                 .Select(x => new PhotoList
                                                 {
                                                     PictureId = x.PictureId,
                                                     PictureName = x.PictureName,
                                                     ProductBagId = x.BagId,
                                                     ProductBagName = x.Product.BagName
                                                 }).DistinctBy(x => x.ProductBagId).ToList();

                return searchForPicture;
            }
        }

        public List<PhotoList> GetAllOfSelectedPicture(int bagIdFromSelectedProduct)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var allImageOfSelectedPicture = db.Picture
                                 .Where(x => x.BagId == bagIdFromSelectedProduct)
                                 .Select(x => new PhotoList
                                 {
                                     PictureName = x.PictureName,
                                 }).ToList();

                return allImageOfSelectedPicture;
            }
        }

        public void UploadSlipPicture(string fileName, int cartId, decimal totalPrice)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var uploadSlip = db.Cart
                    .Where(x => x.CartId == cartId)
                    .ToList();
                foreach (var item in uploadSlip)
                {
                    item.TotalPrice = totalPrice;
                    item.Slip = fileName;
                }
                db.SaveChanges();
            }
        }

        public void UploadPhotoProduct(string filename)
        {
            using (var db = new Bagaround_ShopEntities1())
            {
                var picture = new Picture()
                {
                    PictureName = filename,
                    BagId = db.Product
                                   .Select(x => x.BagId)
                                   .Max()
                };
                db.Picture.Add(picture);
                db.SaveChanges();
            }

        }

        public void AddNewPhotoProduct(string filename,int productId)
        {
            using(var db = new Bagaround_ShopEntities1())
            {
                var picture = new Picture()
                {
                    PictureName = filename,
                    BagId = productId
                };
                db.Picture.Add(picture);
                db.SaveChanges();
            }
        }
    }
}