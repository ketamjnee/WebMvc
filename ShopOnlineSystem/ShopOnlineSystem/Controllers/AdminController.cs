using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineSystem.Models.DAO;
using ShopOnlineSystem.Models.ModelView;

namespace ShopOnlineSystem.Controllers
{
    public class AdminController : Controller
    {
        CategoryDAO cate;
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult category()
        {
            return View();
        }
        public ActionResult addCategory(Category cate1)
        {
            cate = new CategoryDAO();
            if (cate.addCate(cate1.name))
            {
                Session["addcateS"] = "Add Successfully";
            }
            else
            {
                Session["addcateF"] = "Add Fail";
            }
            return RedirectToAction("category");
        }
        public ActionResult editCategory()
        {
            cate = new CategoryDAO();
            var result = cate.getListCate();
            return View(result.ToList());
        }
    }
}