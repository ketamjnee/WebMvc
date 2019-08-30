using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineSystem.Models;
using ShopOnlineSystem.Models.DAO;
using ShopOnlineSystem.Models.ModelView;
namespace ShopOnlineSystem.Controllers
{
    public class AdminController : Controller
    {
        Repository function;
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
            
            if (CategoryDAO.addCate(cate1))
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
            
            var result = CategoryDAO.getListCate();
            return View(result.ToList());
        }
        public ActionResult updateCate(int id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult updateCateDAO(Category cate)
        {

           CategoryDAO.updateCate(cate);
            
            return RedirectToAction("updateCate");
        }
    }
}