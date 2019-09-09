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
                    IDU = 0,
                    Zipcode = "Hihi"
                };
                db.Oders.Add(od);
                return od.id;
            }
            catch (Exception)
            {

                throw;
            }
            return 0;
        }
    }
}