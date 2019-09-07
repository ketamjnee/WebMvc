using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class PView
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }
        public int IDC { get; set; }
        public int StatusProd { get; set; }
        public List<ProImageView> image { get; set; }
        public string CateName { get; set; }
    }
}