using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class Category
    {
        public int ID { get; set; }
        public string name { get; set; }
        public byte statusCat { get; set; }
    }
}