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
            
        }
        public static bool deleteCate(int id)
        {
            try
            {
                Category cate = db.Categories.Find(id) as Category;
                db.Categories.Remove(cate);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }            
        }

        #region Giang
        public static List<ModelView.CategoryView> GetListCateView()
        {
            db = new ShopOnlineEntities();
            var rs = db.Categories.Select(c => new ModelView.CategoryView
            {
                ID = c.id,
                Name = c.name,
                StatusCat = c.StatusCat,
                ProductCount = c.Products.Where(d=>d.IDC == c.id && d.StatusProd == 1).Select(d=>d.id).Count(),
                DeleteStatus = !(
                db.Products.Any(p => p.IDC == c.id)
                )
            }).ToList();
            return rs;
        }
        #endregion
    }
}