﻿using System;
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
                    return item;
                }
            }
            catch (Exception ex)
            {

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
    }
}