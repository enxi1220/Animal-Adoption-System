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
    
    public partial class PET
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PET()
        {
            this.ADOPTIONs = new HashSet<ADOPTION>();
            this.AUDITs = new HashSet<AUDIT>();
            this.EUTHANASIAs = new HashSet<EUTHANASIA>();
        }
    
        public int PETID { get; set; }
        public string PETNO { get; set; }
        public string NAME { get; set; }
        public string AGE { get; set; }
        public string SIZE { get; set; }
        public string GENDER { get; set; }
        public string BREED { get; set; }
        public string TYPE { get; set; }
        public string IMAGE { get; set; }
        public string DESC { get; set; }
        public Nullable<System.DateTime> ADOPTIONTIME { get; set; }
        public string OWNER { get; set; }
        public Nullable<int> AUDITPERIOD { get; set; }
        public string STATUS { get; set; }
        public Nullable<System.DateTime> CREATEDDATE { get; set; }
        public string CREATEDBY { get; set; }
        public Nullable<System.DateTime> UPDATEDDATE { get; set; }
        public string UPDATEDBY { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ADOPTION> ADOPTIONs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AUDIT> AUDITs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EUTHANASIA> EUTHANASIAs { get; set; }
    }
}
