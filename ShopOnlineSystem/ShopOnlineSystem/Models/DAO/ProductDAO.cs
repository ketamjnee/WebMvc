using ShopOnlineSystem.Models.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.DAO

{
    public class ProductDAO
    {
        private static ShopOnlineEntities db = null;
        public ProductDAO()
        {
            db = new ShopOnlineEntities();
        }
        public static bool deleteProduct(int id)
        {
            try
            {
                Product prod = db.Products.Find(id) as Product;
                prod.StatusProd = 2;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }

        }
        public static bool updateProduct(ModelView.ProductView item, HttpPostedFileBase picture)
        {
            db = new ShopOnlineEntities();
            try
            {

                Product p = db.Products.Find(item.id) as Product;
                p.name = item.name;
                p.price = item.price;
                p.stock = item.stock;
                p.description = item.description;
                //p.StatusProd = item.StatusProd
                db.SaveChanges();
                ProImage pi = db.ProImages.Where(pix => pix.IDP == p.id).FirstOrDefault() as ProImage;
                pi.Name = picture.FileName;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
        public static ModelView.ProductView get1Product(int id)
        {
            db = new ShopOnlineEntities();
            IQueryable<ModelView.ProductView> result = from p in db.Products
                                                       where p.id == id
                                                       select new ModelView.ProductView
                                                       {
                                                           id = p.id,
                                                           IDC = p.Category.id,
                                                           CateName = p.Category.name,
                                                           name = p.name,
                                                           price = p.price,
                                                           description = p.description,
                                                           picture = p.ProImages.Where(pi => pi.StatusIMG == 1).FirstOrDefault().Name,
                                                           stock = p.stock
                                                       };
            return result.FirstOrDefault();
        }
        public static List<ModelView.ProductView> getListPro()
        {
            db = new ShopOnlineEntities();
            /*
             lambda
             */
            List<ModelView.ProductView> q = db.Products.Where(d => d.StatusProd == 1).Select(d => new ModelView.ProductView
            {
                id = d.id,
                picture = d.ProImages.Where(f => f.StatusIMG == 1).FirstOrDefault().Name
            }).ToList();
            /*
             select p.*,pi.name
             from product p, proImage pi
             where p.id=pi.idp and p.statusprod=1 and pi.status=1
             */

            IQueryable<ModelView.ProductView> rs = from p in db.Products
                                                   from pi in db.ProImages
                                                   where p.id == pi.IDP && p.StatusProd == 1 && pi.StatusIMG == 1
                                                   select new ModelView.ProductView { id = p.id, picture = pi.Name };
            /*
             select p.*,(select name from proimage where idprod=p.id)
             from product p 
             where p.statusprod=1 
             
             */
            IQueryable<ModelView.ProductView> result = (from prod in db.Products
                                                       where prod.StatusProd == 1
                                                       select new ModelView.ProductView
                                                       {
                                                           id = prod.id,
                                                           name = prod.name,
                                                           description = prod.description,
                                                           IDC = prod.IDC ?? 0,
                                                           price = prod.price,
                                                           stock = prod.stock,
                                                           picture = (prod.ProImages.Where(d => d.StatusIMG == 1 && d.IDP == prod.id).FirstOrDefault()).Name,
                                                           CateName = prod.Category.name
                                                       }).OrderByDescending(prod => prod.id);
            return result.ToList();
        }
        public static bool addProduct(ModelView.ProductView item, HttpPostedFileBase picture)
        {
            try
            {
                db = new ShopOnlineEntities();
                Product p = new Product
                {
                    name = item.name,
                    price = item.price,
                    stock = item.stock,
                    IDC = item.IDC,
                    description = item.description,
                    StatusProd = 1
                };
                db.Products.Add(p);
                db.SaveChanges();
                ProImage img = new ProImage
                {
                    Name = picture.FileName,
                    IDP = p.id,
                    StatusIMG = 1
                };
                db.ProImages.Add(img);
                db.SaveChanges();

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return false;
        }
        public static List<ModelView.ProductView> GetListPaging(int pageindex, int pagesize, int idc)
        {
            db = new ShopOnlineEntities();
            List<ModelView.ProductView> dt = (from a in db.Products
                                              from b in db.ProImages
                                              where a.id == b.IDP && b.StatusIMG == 1 && a.StatusProd == 1 && a.IDC == idc
                                              select new ModelView.ProductView
                                              {
                                                  id = a.id,
                                                  IDC = a.IDC ?? 0,
                                                  CateName = a.Category.name,
                                                  name = a.name,
                                                  description = a.description,
                                                  picture = b.Name,
                                                  price = a.price,
                                                  StatusProd = a.StatusProd,
                                                  stock = a.stock
                                              }).OrderByDescending(a => a.id).Skip(pageindex * pagesize).Take(pagesize).ToList();
            return dt;
        }
        public static ModelView.ProductView getDataByID(int id)
        {
            db = new ShopOnlineEntities();
            ModelView.ProductView rs = (from p in db.Products
                                        from i in db.ProImages
                                        where p.id == id && p.StatusProd == 1 && i.StatusIMG == 1 && i.IDP == p.id
                                        select new ModelView.ProductView
                                        {
                                            id = p.id,
                                            IDC = p.IDC ?? 0,
                                            CateName = p.Category.name,
                                            name = p.name,
                                            description = p.description,
                                            picture = i.Name,
                                            price = p.price,
                                            StatusProd = p.StatusProd,
                                            stock = p.stock
                                        }).FirstOrDefault();
            return rs;
        }
        public static List<ModelView.ProductView> getListTitle(int pagesize)
        {
            db = new ShopOnlineEntities();
            //var rs = db.Products.OrderByDescending(p => p.id).Take(pagesize).Where(p => p.StatusProd == 1).Select(p => new ModelView.ProductView
            //{
            //    id = p.id,
            //    IDC = p.IDC ?? 0,
            //    CateName = p.Category.name,
            //    name = p.name,
            //    description = p.description,
            //    picture = (
            //          p.ProImages.Where(i => i.IDP == p.id && i.StatusIMG == 1).FirstOrDefault()
            //          ).Name,
            //    price = p.price,
            //    StatusProd = p.StatusProd,
            //    stock = p.stock
            //}).ToList();
            List<ModelView.ProductView> dt = (from a in db.Products
                                              from b in db.ProImages
                                              where a.id == b.IDP && b.StatusIMG == 1 && a.StatusProd == 1
                                              select new ModelView.ProductView
                                              {
                                                  id = a.id,
                                                  IDC = a.IDC ?? 0,
                                                  CateName = a.Category.name,
                                                  name = a.name,
                                                  description = a.description,
                                                  picture = b.Name,
                                                  price = a.price,
                                                  StatusProd = a.StatusProd,
                                                  stock = a.stock
                                              }).OrderByDescending(a => a.id).Take(pagesize).ToList();
            return dt;
        }

        public static int AddProduct(ModelView.PView item)
        {
            db = new ShopOnlineEntities();
            Product pro = new Product
            {
                description = item.description,
                IDC = item.IDC,
                name = item.name,
                price = item.price,
                StatusProd = 1,
                stock = item.stock
            };
            db.Products.Add(pro);
            db.SaveChanges();
            return pro.id;
        }
        public static List<ModelView.PView> GetListProdVIew()
        {
            db = new ShopOnlineEntities();
            List<ModelView.PView> rs = db.Products.Where(p => p.StatusProd == 1).Select(p => new ModelView.PView
            {
                id = p.id,
                IDC = p.IDC ?? 0,
                CateName = p.Category.name,
                description = p.description,
                name = p.name,
                StatusProd = p.StatusProd,
                price = p.price,
                stock = p.stock,
                image = (db.ProImages.Where(i => i.IDP == p.id).Select(i => new ModelView.ProImageView
                {
                    ID = i.ID,
                    IDP = i.IDP ?? 0,
                    Name = i.Name,
                    StatusIMG = i.StatusIMG
                }).OrderBy(i=>i.ID).Take(4).ToList())
            }).ToList();
            return rs;
        }
        public static ModelView.PView GetProdByID(int id)
        {
            db = new ShopOnlineEntities();
            var rs = db.Products.Where(p => p.StatusProd == 1 && p.id == id).Select(p => new ModelView.PView
            {
                id = p.id,
                IDC = p.IDC ?? 0,
                CateName = p.Category.name,
                description = p.description,
                name = p.name,
                StatusProd = p.StatusProd,
                price = p.price,
                stock = p.stock,
                image = (db.ProImages.Where(i => i.IDP == p.id).Select(i => new ModelView.ProImageView
                {
                    ID = i.ID,
                    IDP = i.IDP ?? 0,
                    Name = i.Name,
                    StatusIMG = i.StatusIMG
                }).ToList())
            }).SingleOrDefault();
            return rs;
        }
    }
}