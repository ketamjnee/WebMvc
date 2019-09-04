using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class CategoryView
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte StatusCat { get; set; }
        public int ProductCount { get; set; }

        public bool DeleteStatus { get; set; }

    }
}