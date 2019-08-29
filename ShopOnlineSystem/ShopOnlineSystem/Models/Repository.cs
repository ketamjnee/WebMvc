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
        public static List<ModelData.Category> getListCate()
        {
            return CategoryDAO.getListCate();
        }
        public static bool addCate(string name)
        {
            return CategoryDAO.addCate(name);
        }
        public static bool updateCate(int id, string name, bool a)
        {
            return CategoryDAO.updateCate(id, name, a);
        }
        #endregion

    }


}