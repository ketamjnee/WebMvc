using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopOnlineSystem.Models.ModelView
{
    public class CommentView
    {
        public int id { get; set; }
        public string email { get; set; }
        public string comment { get; set; }
        public string typeFB { get; set; }
        public int typeComment { get; set; }
    }
}