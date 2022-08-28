using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Models
{
    public class HomeModel
    {
        public List<dbProduct> ListProduct { get; set; }
        public List<dbCategory> ListCategory { get; set; }
    }
}