using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace memes.Models
{
    public class BagViewModel
    {
        public int Id { get; set; }
        public string Size { get; set; }
        public decimal Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Total { get; set; }
        public byte[] Image { get; set; }
        public string ItemName { get; set; }
    }
}