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
        public static bool addCate(ModelView.Category item)
        {
            return CategoryDAO.addCate(item);
        }
        public static bool updateCate(ModelView.Category item)
        {
            return CategoryDAO.updateCate(item);
        }
        #endregion

    }


}