using ShopOnlineSystem.Models.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.DAO
{
    public class CategoryDAO
    {
        
        ShopOnlineEntities db = null;
        public CategoryDAO()
        {
            db = new ShopOnlineEntities();
        }
        public List<Category> getListCate()
        {
            var result = from viet in db.Categories select viet;
            //List<Category> cate = result;
               
            return result.ToList();
        }
        public bool addCate(string name)
        {
            try
            {
                Category cate = new Category(); 
                cate.name = name;
                db.Categories.Add(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
    }
}