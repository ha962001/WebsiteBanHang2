using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objwebsiteBanHangEntities = new WebsiteBanHangEntities();

        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objwebsiteBanHangEntities.dbProducts.Where(n => n.ID == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}