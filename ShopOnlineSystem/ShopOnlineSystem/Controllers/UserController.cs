using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopOnlineSystem.Models;
using ShopOnlineSystem.Models.ModelView;
using ShopOnlineSystem.Models.DAO;
using Newtonsoft.Json;

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
            ViewBag.STT = 0;
            if(id == null)
            {
                RedirectToAction("Index");
            }
            PView pv = Repository.GetProdViewByID(Convert.ToInt32(id));
            ViewBag.Prod = pv;
            return View();
        }
        public ActionResult addCart(cartView item)
        {
            if (Request.Cookies["cartItem"] == null)
            {
                cartView cv = new cartView { idPro = item.idPro, quantity = item.quantity, name = item.name,price = item.price };
                List<cartView> lcv = new List<cartView>();
                lcv.Add(cv);
                string rs = JsonConvert.SerializeObject(lcv);
                HttpCookie ck = new HttpCookie("cartItem", rs);
                ck.Expires.AddDays(2);
                Response.Cookies.Add(ck);
            }
            else
            {
                string rs = Request.Cookies["cartItem"].Value;
                List<cartView> lcv = JsonConvert.DeserializeObject<List<cartView>>(rs);
                var obj = lcv.FirstOrDefault(x => x.idPro == item.idPro);
                if (obj != null) {
                    obj.quantity += 1;
                } else {
                    cartView cv = new cartView { idPro = item.idPro, quantity = item.quantity, name = item.name, price = item.price };
                    lcv.Add(cv); }
                rs = JsonConvert.SerializeObject(lcv);
                Response.Cookies["cartItem"].Value = rs;
            }
            return RedirectToAction("Product", new { id = item.idPro });
        }
        public ActionResult Cart()
        {
            if (Request.Cookies["cartItem"] == null)
            {
                ViewBag.CartError = "Không có sản phẩm trong giỏ hàng";
            }
            else
            {
                string rs = Request.Cookies["cartItem"].Value;
                List<cartView> lcv = JsonConvert.DeserializeObject<List<cartView>>(rs);
                ViewBag.cartItem = lcv;
            }
            
            return View();
        }
        public ActionResult deleteCart(int id)
        {
            string rs = Request.Cookies["cartItem"].Value;
            List<cartView> lcv = JsonConvert.DeserializeObject<List<cartView>>(rs);
            var item = lcv.Single(r => r.idPro == id);
            lcv.Remove(item);
            rs = JsonConvert.SerializeObject(lcv);
            Response.Cookies["cartItem"].Value = rs;
            return RedirectToAction("Cart");
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
                Session["emailUser"] = user.email;
                if (user.userType == 1)
                {
                    Session["userType"] = "Admin";
                    return RedirectToAction("Index", "Admin");
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
            if (Repository.updateInfo(item))
            {
                Session["nameUser"] = item.name;
                Session["Success"] = "Cập nhật thành công"; 
                return RedirectToAction("UserProfile");
            }
            else
            {
                Session["Error"] = "Cập nhật thất bại";
                return RedirectToAction("UserProfile");
            }
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
        public ActionResult feddBackDAO(CommentView item)
        {
            if (item.email != null)
            {
                Repository.addFeedBack(item);
                return RedirectToAction("Index");
            }
            else { return RedirectToAction("Feedback"); }

            
        }
        public ActionResult clearCookie()
        {
            string[] myck = Request.Cookies.AllKeys;
            foreach (var item in myck)
            {
                Response.Cookies[item].Expires = DateTime.Now.AddDays(-1);
            }
            return RedirectToAction("Index");
        }
    }
}