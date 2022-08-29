using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebsiteBanHang.Context;

namespace website2202.Areas.Admin.Controllers
{
    public class dbCategoryController : Controller
    {
        WebsiteBanHangEntities objWebsitebanhangEntities = new WebsiteBanHangEntities();
        // GET: Admin/dbCategory
        public ActionResult Index(string CurrrentFilter, string SearchString, int? page)
        {
            var lstdbCategory = new List<dbCategory>();
            if (SearchString != null)
            {
                page = 1;
            }
            else
            {
                SearchString = CurrrentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                //lấy ds sp theo từ khóa tìm kiếm
                lstdbCategory = objWebsitebanhangEntities.dbCategories.Where(n => n.Name.Contains(SearchString)).ToList();
            }
            else
            {
                //lấy tất cả sản phẩm trong bảng product
                lstdbCategory = objWebsitebanhangEntities.dbCategories.ToList();
            }
            ViewBag.CurrrentFilter = SearchString;
            //số lg iteam của 1 trang =4
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            //sắp xếp theo id sp, sp mới đưa lên đầu
            lstdbCategory = lstdbCategory.OrderByDescending(n => n.ID).ToList();
            return View(lstdbCategory.ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult Create()
        {


            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Create(dbCategory objdbCategory)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    if (objdbCategory.ImageUpload != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(objdbCategory.ImageUpload.FileName);
                        string extension = Path.GetExtension(objdbCategory.ImageUpload.FileName);
                        fileName = fileName + extension;
                        objdbCategory.Avatar = fileName;
                        objdbCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
                    }
                    objdbCategory.CreatedOnUtc = DateTime.Now;
                    objWebsitebanhangEntities.dbCategories.Add(objdbCategory);
                    objWebsitebanhangEntities.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }
            return View(objdbCategory);
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var objdbCategory = objWebsitebanhangEntities.dbCategories.Where(n => n.ID == id).FirstOrDefault();
            return View(objdbCategory);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var objdbCategory = objWebsitebanhangEntities.dbCategories.Where(n => n.ID == id).FirstOrDefault();
            return View(objdbCategory);
        }
        [HttpPost]
        public ActionResult Delete(dbCategory objCat)
        {
            var objdbCategory = objWebsitebanhangEntities.dbCategories.Where(n => n.ID == objCat.ID).FirstOrDefault();
            objWebsitebanhangEntities.dbCategories.Remove(objdbCategory);
            objWebsitebanhangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var objdbCategory = objWebsitebanhangEntities.dbCategories.Where(n => n.ID == id).FirstOrDefault();
            return View(objdbCategory);
        }
        [HttpPost]
        public ActionResult Edit(int id, dbCategory objdbCategory)
        {
            if (objdbCategory.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objdbCategory.ImageUpload.FileName);
                string extension = Path.GetExtension(objdbCategory.ImageUpload.FileName);
                fileName = fileName + "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss")) + extension;
                objdbCategory.Avatar = fileName;
                objdbCategory.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images"), fileName));
            }
            objWebsitebanhangEntities.Entry(objdbCategory).State = System.Data.Entity.EntityState.Modified;
            objWebsitebanhangEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}