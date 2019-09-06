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
            ViewBag.Prod = Repository.GetListProdTitle(9);
            return View();
        }
        public ActionResult Category()
        {
            ViewBag.Cat = Repository.GetListCat();
            return View();
        }
        public ActionResult Product(string id)
        {
            if(id == null)
            {
                RedirectToAction("Index");
            }
            ProductView pv = Repository.GetProdByID(Convert.ToInt32(id));
            ViewBag.Prod = pv;
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
                Session["userType"] = "User";
                if (user.userType == 1)
                {
                    Session["userType"] = "Admin";
                    return RedirectToAction("Index", "Admin", new { id = user.id });
                }
                else
                {
                    return RedirectToAction("Index");
                }

            }
            else {
                Session["ErrorLogin"] = "Email hoặc mật khẩu không đúng"; 
                return RedirectToAction("Login");
            }

        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult registerDAO(UserView item)
        {

            if (!Repository.checkMail(item.email))
            {
                if (item.pwd == item.repwd)
                {
                    Repository.addUser(item);
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Register");
                }
            }
            else
            {

                Session["Error"] = "Email đã tồn tại";
                return RedirectToAction("Register");
            }

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
            //Gáy nàoD:\WFC Demo\GitHub\ketamjnee\WebMvc\ShopOnlineSystem\ShopOnlineSystem\Models\DAO\ProductDAO.cs
            item.id = Convert.ToInt32(Session["idUser"]);
            var rs = Repository.updateInfo(item);
            return RedirectToAction("UserProfile");
        }
        public ActionResult Order()
        {
            return View();
        }
        public ActionResult Feedback()
        {
            return View();
        }
    }
}