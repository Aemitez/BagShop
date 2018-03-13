using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bagaround.Models
{
    public class PhotoList
    {
        public int PictureId { get; set; }
        public string PictureName { get; set; }
        public string ProductBagName { get; set; }
        public int ProductBagId { get; set; }

    }
}