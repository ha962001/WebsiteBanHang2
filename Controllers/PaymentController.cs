using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;
using WebsiteBanHang.Models;

namespace WebsiteBanHang.Controllers
{
    public class PaymentController : Controller
    {
        WebsiteBanHangEntities objwebsiteBanHangEntities = new WebsiteBanHangEntities();
        // GET: Payment
        public ActionResult Index()
        {
            if (Session["IdUser"] == null)
            {
                return RedirectToAction("Login", "Home");
            }    
            else
            {
                var lstCart = (List<CartModel>)Session["cart"];
                dbOder objOder = new dbOder();
                objOder.Name = "Don Hang-" + DateTime.Now.ToString("yyyyMMddHHmmss");
                objOder.UserId = int.Parse(Session["IdUser"].ToString());
                objOder.CreatedOnUtc = DateTime.Now;
                objOder.Status = 1;
                objwebsiteBanHangEntities.dbOders.Add(objOder);
                objwebsiteBanHangEntities.SaveChanges();

                int intOderId = objOder.ID;
                List<dbOderDetail> lstOderDetail = new List<dbOderDetail>();
                foreach(var item in lstCart)
                {
                    dbOderDetail obj = new dbOderDetail();
                    obj.Quantity = item.Quantity;
                    obj.OderID = intOderId;
                    obj.ProductID = item.Product.ID;
                    lstOderDetail.Add(obj);
                }
                objwebsiteBanHangEntities.dbOderDetails.AddRange(lstOderDetail);
                objwebsiteBanHangEntities.SaveChanges();
            }
            return View();
        }
    }
}