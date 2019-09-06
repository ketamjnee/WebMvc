using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopOnlineSystem.Models.ModelData;
namespace ShopOnlineSystem.Models.DAO
{
    public class UserDAO
    {
        static ShopOnlineEntities db = null;
        public UserDAO()
        {
            db = new ShopOnlineEntities();
        }
        public static bool checkMail(string emailWeb)
        {
            db = new ShopOnlineEntities();
            try
            {
                var a = db.WebUsers.Where(x => x.email == emailWeb).Count();
                if (a > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
        public static ModelView.UserView getUserId(int Id)
        {
            db = new ShopOnlineEntities();
            WebUser user1 = db.WebUsers.Find(Id) as WebUser;
            ModelView.UserView uv = new ModelView.UserView();
            try
            {
                uv.name = user1.name;
                uv.uAddress = user1.uAddress;
                uv.email = user1.email;
                uv.pwd = user1.pwd;
                uv.repwd = user1.pwd;
                uv.phone = user1.phone;
                uv.zipcode = user1.zipcode;
                uv.username = user1.username;
                uv.avatar = user1.avatar;
                return uv;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return uv;
        }
        public static bool updateInfo(ModelView.UserView item)
        {
            db = new ShopOnlineEntities();
            
            try
            {
                WebUser user1 = db.WebUsers.Find(item.id) as WebUser;
                user1.name = item.name;
                user1.uAddress = item.uAddress;
                user1.pwd = item.pwd;
                user1.phone = item.phone;
                user1.zipcode = item.zipcode;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
            
        }
        public static ModelView.UserView loginUser(ModelView.UserView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                WebUser user = db.WebUsers.Where(x => x.email == item.email && x.pwd == item.pwd).FirstOrDefault() as WebUser;
                if (user.ID > 0)
                { 
                    item.id = user.ID;
                    item.userType = user.usertype;
                    item.name = user.name;
                    return item;
                }
            }
            catch (Exception ex)
            {
                return item;
                throw ex;
            }
            return item;
        }
        public static bool addUser(ModelView.UserView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                WebUser user = new WebUser
                {
                    username = item.username,
                    email = item.email,
                    pwd = item.pwd,
                    name = item.name,
                    uAddress = item.uAddress,
                    phone = item.phone,
                    zipcode = item.zipcode
                };
                db.WebUsers.Add(user);
                db.SaveChanges();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return false;
        }
        public static bool addFeedBack(ModelView.CommentView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                Comment cm = new Comment
                {
                    Comment1 = item.comment,
                    email = item.email,
                    typeComment = 0,
                    typeFB = item.typeFB
                };
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }
    }
}