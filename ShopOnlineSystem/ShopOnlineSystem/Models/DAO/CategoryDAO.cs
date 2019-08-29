using ShopOnlineSystem.Models.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace ShopOnlineSystem.Models.DAO
{
    public class CategoryDAO
    {
        
       static ShopOnlineEntities db = null;
        public CategoryDAO()
        {
            db = new ShopOnlineEntities();
        }
        public static List<Category> getListCate()
        {
            db = new ShopOnlineEntities();
            var result = from viet in db.Categories select viet;
            //List<Category> cate = result;
               
            return result.ToList();
        }
        public static bool addCate(string name)
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
        public static bool updateCate(int id, string name, bool a)
        {
            try
            {
                Category cate = db.Categories.Find(id) as Category;
                cate.name = name;
                cate.StatusCat = a;
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