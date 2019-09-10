using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class ResetPasswordView
    {
        public string pwd { get; set; }
        public string repwd { get; set; }
        public string ResetCode { get; set; }
    }
}