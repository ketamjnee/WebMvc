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
    
    public partial class Oder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Oder()
        {
            this.OderDetails = new HashSet<OderDetail>();
        }
    
        public int id { get; set; }
        public string CustName { get; set; }
        public string CustAddress { get; set; }
        public string CustEmail { get; set; }
        public string CustPhone { get; set; }
        public string Zipcode { get; set; }
        public Nullable<int> IDU { get; set; }
        public Nullable<System.DateTime> DayCreate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OderDetail> OderDetails { get; set; }
    }
}