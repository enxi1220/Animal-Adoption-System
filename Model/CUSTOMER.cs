//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AnimalAdoptionSystem.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CUSTOMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CUSTOMER()
        {
            this.ADOPTIONs = new HashSet<ADOPTION>();
        }
    
        public int CUSTOMERID { get; set; }
        public string USERNAME { get; set; }
        public string STATUS { get; set; }
        public string NAME { get; set; }
        public string PASSWORD { get; set; }
        public string PHONE { get; set; }
        public string MAIL { get; set; }
        public string OTP { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
        public string IMAGE { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADOPTION> ADOPTIONs { get; set; }
    }
}
