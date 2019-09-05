using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineSystem.Models;
using ShopOnlineSystem.Models.ModelView;
using ShopOnlineSystem.Models.DAO;
namespace ShopOnlineSystem.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Category()
        {
            ViewBag.Cat = Repository.GetListCat();
            return View();
        }
        public ActionResult Product()
        {
            return View();
        }
        public ActionResult Cart()
        {
            return View();
        }
        public ActionResult Checkout()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session["idUser"] = null;
            return RedirectToAction("Index");
        }
        public ActionResult loginDAO(UserView item)
        {
            UserView user = Repository.loginUser(item);
            if (user.id > 0)
            {
                Session["idUser"] = user.id;
                Session["nameUser"] = user.name;
                if (user.userType == 1)
                {
                    return RedirectToAction("Index", "Admin", new {id = user.id });
                }
                else
                {
                    return RedirectToAction("Index");
                }
               
            }
            else { return RedirectToAction("Login");
            }
            
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult registerDAO(UserView item)
        {
            if (Repository.
                checkMail(item.email))
            {
                 return RedirectToAction("Register");
            }
            else { return RedirectToAction("Index"); }
            //if (item.pwd == item.repwd)
            //{

            //    Repository.addUser(item);
            //}
            //else
            //{
            //    View("Register");
            //}
            //return RedirectToAction("Index");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult UserProfile()
        {
            if (Session["idUser"] == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                int id = Convert.ToInt32(Session["idUser"]);
                var rs = Repository.getUserId(id);
                return View(rs);
            }

        }
        public ActionResult UpdateUserDAO(UserView item)
        {
            //Gáy nào
            item.id = Convert.ToInt32(Session["idUser"]);
            var rs = Repository.updateInfo(item);
            return RedirectToAction("UserProfile");
        }
    }
}