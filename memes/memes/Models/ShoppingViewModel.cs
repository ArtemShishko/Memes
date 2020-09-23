using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace memes.Models
{
    public class ShoppingViewModel
    {
        public int Id { get; set; }
        public string Gender { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Size { get; set; }
        public decimal Price { get; set; }
        public byte[] Image { get; set; }
        public string Color { get; set; }
        public string BrandInfo { get; set; }
        public string LookAfter { get; set; }
        public string About { get; set; }
        public string MoreDetails { get; set; }
        public byte[] ExtraImage { get; set; }
        public string style { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItem { get; set; }
    }
}