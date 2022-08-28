using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Models
{
    public class CartModel
    {
        public dbProduct Product { get; set; }
         public int Quantity { get; set; }
    }
}

