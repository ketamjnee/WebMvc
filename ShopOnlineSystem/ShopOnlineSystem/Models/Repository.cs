using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopOnlineSystem.Models;
using ShopOnlineSystem.Models.DAO;

namespace ShopOnlineSystem.Models
{
    public class Repository
    {
        #region category
        public static bool deleteCate(int id)
        {
            return CategoryDAO.deleteCate(id);
        }
        public static List<ModelData.Category> getListCate()
        {
            return CategoryDAO.getListCate();
        }
        public static bool addCate(ModelView.Category item)
        {
            return CategoryDAO.addCate(item);
        }
        public static bool updateCate(ModelView.Category item)
        {
            return CategoryDAO.updateCate(item);
        }
        public static List<ModelView.CategoryView> GetListCateView()
        {
            return CategoryDAO.GetListCateView();
        }
        public static List<ModelView.Category> GetListCat()
        {
            return CategoryDAO.GetList();
        }
        #endregion
        
        #region product
        public static bool deleteProduct(int id)
        {
            return ProductDAO.deleteProduct(id);
        }
        public static bool updateProduct(ModelView.ProductView item, HttpPostedFileBase picture)
        {
            return ProductDAO.updateProduct(item, picture);
        }
        public static ModelView.ProductView get1Product(int id)
        {
            return ProductDAO.get1Product(id);
        }
        public static List<ModelView.ProductView> getListPro()
        {
            return ProductDAO.getListPro();
        }
        public static bool addProduct(ModelView.ProductView item, HttpPostedFileBase picture)
        {
            return ProductDAO.addProduct(item, picture);
        }
        #endregion
        
        #region user
       public static bool addUser(ModelView.UserView item)
        {
            return UserDAO.addUser(item);
        }
        public static ModelView.UserView loginUser(ModelView.UserView item)
        {
            return UserDAO.loginUser(item);
        }
        #endregion
    }


}