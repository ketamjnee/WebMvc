//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopOnlineSystem.Models.ModelData
{
    using System;
    using System.Collections.Generic;
    
    public partial class OderDetail
    {
        public int IDO { get; set; }
        public int IDP { get; set; }
        public int quantity { get; set; }
        public decimal total { get; set; }
        public bool StatusPay { get; set; }
    
        public virtual Oder Oder { get; set; }
        public virtual Product Product { get; set; }
    }
}
