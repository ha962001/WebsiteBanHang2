using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Hmoe
        public ActionResult Index()
        {
            return View();
        }
    }
}