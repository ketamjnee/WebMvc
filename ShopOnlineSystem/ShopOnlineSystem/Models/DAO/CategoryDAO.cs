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
            var result = from viet in db.Categories where viet.StatusCat == 1 select viet;
            //List<Category> cate = result;
               
            return result.ToList();
        }
        public static bool addCate(ModelView.Category item)
        {
                db = new ShopOnlineEntities();
                Category cate = new Category {
                    name = item.name,
                    StatusCat = 1
                };
                db.Categories.Add(cate);
                return db.SaveChanges()>0;
        }
        public static bool updateCate(ModelView.Category item)
        {
            try
            {
                Category cate = db.Categories.Find(item.ID) as Category;
                cate.name = item.name;
                cate.StatusCat = 1;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            return false;
        }
        public static bool deleteCate(int id)
        {
            try
            {
                Category cate = db.Categories.Find(id) as Category;
                cate.StatusCat = 2;
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