using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopOnlineSystem.Models;
using ShopOnlineSystem.Models.ModelData;
namespace ShopOnlineSystem.Models.DAO
{
    public class ProImageDAO
    {
        public static bool AddNewImage(ModelView.ProImageView item)
        {
            ShopOnlineEntities en = new ShopOnlineEntities();
            ProImage pi = new ProImage { Name = item.Name, IDP = item.IDP, StatusIMG = item.StatusIMG };
            en.ProImages.Add(pi);
            return en.SaveChanges() > 0;
        }
    }   
}