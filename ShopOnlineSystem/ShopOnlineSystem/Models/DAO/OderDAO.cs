using ShopOnlineSystem.Models.ModelData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.DAO
{
    public class OderDAO
    {
       public static ShopOnlineEntities db = null;
        public OderDAO()
        {
            db = new ShopOnlineEntities();
        }
        public static int addOder(ModelView.OderView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                Oder od = new Oder
                {
                    CustAddress = item.CustAddress,
                    CustEmail = item.CustEmail,
                    CustName = item.CustName,
                    CustPhone = item.CustPhone,
                    DayCreate = DateTime.Today,
                    IDU = item.IDU,
                    Zipcode = "Hihi"
                };
                db.Oders.Add(od);
                db.SaveChanges();
                return od.id;
            }
            catch (Exception)
            {

                throw;
            }
            return 0;
        }
        public static bool addOderDt(ModelView.oderDetailView item)
        {
            db = new ShopOnlineEntities();
            try
            {
                OderDetail odt = new OderDetail
                {
                    IDO = item.IDO,
                    IDP = item.IDP,
                    quantity = item.quantity,
                    total = item.total,
                    StatusPay = false
                   
                };
                db.OderDetails.Add(odt);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
                throw;
            }
            
        }
    }
}