using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class OderView
    {
        public int id { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustEmail { get; set; }
        public string CustPhone { get; set; }
        public string Zipcode { get; set; }
        public int IDU { get; set; }
        public DateTime DayCreate { get; set; }
       
    }
}