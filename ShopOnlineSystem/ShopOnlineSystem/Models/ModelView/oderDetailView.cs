using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class oderDetailView
    {
        public int IDO { get; set; }
        public int IDP { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
        public bool StatusPay { get; set; }
      
    }
}