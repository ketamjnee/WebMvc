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
    
    public partial class Image
    {
        public int id { get; set; }
        public string avatar { get; set; }
        public Nullable<int> IDP { get; set; }
        public bool StatusIMG { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
