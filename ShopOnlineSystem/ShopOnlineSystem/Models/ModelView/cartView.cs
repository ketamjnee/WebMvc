using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class cartView
    {
        public int idPro { get; set; }
        public int quantity { get; set; }
        public string name { get; set; }
        public int price { get; set; }
    }
}