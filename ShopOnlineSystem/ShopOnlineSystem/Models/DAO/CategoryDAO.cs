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
        public static List<ModelView.Category> getCatPaging(int pageindex,int pagesize)
        {
            db = new ShopOnlineEntities();
            var c = db.Categories.OrderBy(d => d.id).Skip(pageindex*pagesize).Take(pagesize).Select(f => new ModelView.Category {ID=f.id,name=f.name,statusCat=Convert.ToInt32(f.StatusCat)});
            return c;
        }
    }
}