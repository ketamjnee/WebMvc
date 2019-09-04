using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineSystem.Models;
using ShopOnlineSystem.Models.ModelView;

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
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult registerDAO(UserView item)
        {
            if (item.pwd == item.repwd)
            {
                Repository.addUser(item);
            }
            else
            {
                View("Register");
            }
            return RedirectToAction("Index");
        }
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult UserProfile()
        {
            return View();
        }
    }
}