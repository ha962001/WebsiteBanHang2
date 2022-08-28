using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Controllers
{
    public class CategoryController : Controller
    {
        WebsiteBanHangEntities objwebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Category
        public ActionResult Detail()
        {
            var lstCategory = objwebsiteBanHangEntities.dbCategories.ToList();
            return View(lstCategory);
        }
        public  ActionResult ProductCategory(int Id)
        {
            var lstProduct= objwebsiteBanHangEntities.dbProducts.Where(n=>n.CategoryID==Id).ToList();
            return View(lstProduct);
        }
    }
}