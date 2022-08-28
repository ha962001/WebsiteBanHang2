using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace WebsiteBanHang.Areas.Admin.Controllers
{
                public class ProductController : Controller
                {
                    WebsiteBanHangEntities objwebsiteBanHangEntities = new WebsiteBanHangEntities();
                    // GET: Admin/Product
                public ActionResult Index(string currentFilter, string SearchString, int? page)
                { 
                var lstProduct = new List<dbProduct>();
                if(SearchString!=null)
                {
                page = 1;
                }
                else
                {    
               SearchString = currentFilter;
                }
            if (!string.IsNullOrEmpty(SearchString))
            {
                // lấy ds sản phẩm theo từ khóa tìm kiếm
                lstProduct = objwebsiteBanHangEntities.dbProducts.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {

                // lay all sån phâm trong bång product
                lstProduct = objwebsiteBanHangEntities.dbProducts.ToList();
            }
            ViewBag.CurrentFilter= SearchString;
            // số lượng item của1trang-4

            int pageSize = 4;
            int pageNumber = (page ?? 1);
            // sắp xếp theo id sản phẩm áp mới đưa lên đầu
            lstProduct =lstProduct.OrderByDescending(n=>n.ID).ToList();
            return View(lstProduct.ToPagedList(pageNumber, pageSize));

}


[HttpGet]
            public ActionResult Create()
            {

                return View();
            }
            [HttpPost]
            public ActionResult Create(dbProduct ojbProduct)
            {
                try
                {
                    if (ojbProduct.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ojbProduct.ImageUpload.FileName);
                        string extension = Path.GetExtension(ojbProduct.ImageUpload.FileName);
                        fileName = fileName + extension;
                        ojbProduct.Avatar = fileName;
                        ojbProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                    }
                objwebsiteBanHangEntities.dbProducts.Add(ojbProduct);
                objwebsiteBanHangEntities.SaveChanges();
                    return RedirectToAction("Index");

                }
                catch (Exception)
                {
                    return RedirectToAction("Index");
                }

            }


            [HttpGet]
            public ActionResult Details(int Id)
            {
                var ojbProduct = objwebsiteBanHangEntities.dbProducts.Where(n => n.ID == Id).FirstOrDefault();
                return View(ojbProduct);
            }

            [HttpGet]
            public ActionResult Delete(int Id)
            {
                var ojbProduct = objwebsiteBanHangEntities.dbProducts.Where(n => n.ID == Id).FirstOrDefault();
                return View(ojbProduct);
            }

            [HttpPost]
            public ActionResult Delete(dbProduct objPro)
            {
                var ojbProduct = objwebsiteBanHangEntities.dbProducts.Where(n => n.ID == objPro.ID).FirstOrDefault();

            objwebsiteBanHangEntities.dbProducts.Remove(ojbProduct);
            objwebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            [HttpGet]
            public ActionResult Edit(int Id)
            {
                var ojbProduct = objwebsiteBanHangEntities.dbProducts.Where(n => n.ID == Id).FirstOrDefault();
                return View(ojbProduct);
            }


            [HttpPost]
            public ActionResult Edit(int Id, dbProduct ojbProduct)
            {
                if (ojbProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ojbProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(ojbProduct.ImageUpload.FileName);
                    fileName = fileName + extension;
                    ojbProduct.Avatar = fileName;
                    ojbProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
            objwebsiteBanHangEntities.Entry(ojbProduct).State = EntityState.Modified;
            objwebsiteBanHangEntities.SaveChanges();
                return RedirectToAction("Index");
            }
      


    }
    } 