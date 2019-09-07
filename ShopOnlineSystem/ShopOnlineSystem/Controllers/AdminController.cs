using System;
using System.Collections.Generic;
using System.IO;
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
        public ActionResult Index()
        {
             return View();
            
        }
        #region category
        public ActionResult category()
        {
            return View();
        }
        public ActionResult addCategory(Category cate1)
        {
            if (Repository.addCate(cate1))
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
            var result = Repository.GetListCateView();
            ViewBag.Cat = result;
            return View();
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
        public ActionResult deleteCate(int id)
        {
             Repository.deleteCate(id); 
            return RedirectToAction("editCategory");
        }
        #endregion

        #region product
        public ActionResult addProduct()
        {
            var result = Repository.getListCate();
            return View(result.ToList());
        }
        public ActionResult deletePro(int id)
        {
            Repository.deleteProduct(id);
            return RedirectToAction("editProduct");
        }
        public ActionResult addProductDAO(PView item,HttpPostedFileBase[] picture)
        {
            int id = Repository.AddProduct(item);
            int count = 0;
            if (picture != null)
            {
                foreach (var p in picture)
                {
                    byte status = 2;
                    string path = Path.Combine(Server.MapPath("~/Content/Picture/Admin/Product"), Path.GetFileName(p.FileName));
                    p.SaveAs(path);
                    if (count == 0)
                    {
                        status = 1;
                    }
                    Repository.AddImage(new ProImageView { Name = p.FileName, IDP = id, StatusIMG = status });
                    count++;
                }               
            }
            
            return RedirectToAction("editProduct");
        }
        public ActionResult editProduct()
        {
            var result = Repository.getListPro();
            return View(result);
        }
        public ActionResult updatePro(int id)
        {
            var result = Repository.get1Product(id);
            return View(result);
        }
        public ActionResult updateProDAO(ProductView item, HttpPostedFileBase picture)
        {
            if (picture != null)
            {
                string path = Path.Combine(Server.MapPath("~/Content/Picture/Admin/Product"), Path.GetFileName(picture.FileName));
                picture.SaveAs(path);
            }
            Repository.updateProduct(item,picture);
            return RedirectToAction("editProduct");
        }
        #endregion
        #region Setting
        public ActionResult userSetting()
        {
            if (Session["idUser"] != null)
            {
                int id = Convert.ToInt16(Session["idUser"]);
                var rs = Repository.getUserId(id);
                return View(rs);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        public ActionResult updateAdminDAO(UserView item)
        {
            item.id = Convert.ToInt16(Session["idUser"]); 
            if (item.pwd == item.repwd)
            {
                    if (Repository.updateInfo(item))
                    {
                        Session["Success"] = "Cập nhật thành công";
                        return RedirectToAction("userSetting");
                    }
                    else
                    {
                        Session["Error"] = "Cập nhật thất bại";
                        return RedirectToAction("userSetting");
                    }
            }
            else
            {
                return RedirectToAction("userSetting");
            }
            return View();
        }
        public ActionResult LogoutAdmin()
        {
            Session["idUser"] = null;
            Session["userType"] = null;
            return RedirectToAction("Index", "User");
        }
        #endregion
        #region Tương tác
        public ActionResult OrderAdmin()
        {
            return View();
        }
        public ActionResult FeedbackAdmin()
        {
            return View();
        }
        #endregion
    }
}