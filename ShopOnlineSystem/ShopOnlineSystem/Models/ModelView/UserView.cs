using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class UserView
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public string repwd { get; set; }
        public string name { get; set; }
        public string uAddress { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string zipcode { get; set; }
        public string avatar { get; set; }
        public int userType { get; set; }

    }
}